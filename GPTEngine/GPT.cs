using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Text;

namespace GPTEngine
{
    public class GPT
    {
        string _apiUrl;
        string _apiKey;

        HttpClient _httpClient = new HttpClient();
        public GPT()
        {
            _apiUrl = "https://api.openai.com/v1/chat/completions";
            _apiKey = "Put Ya Key Here"; // Replace with your valid API key

            // Set up HttpClient
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Architext");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<GPTResponse> Call(Conversation request)
        {
            GPTResponse response = null;

            // Serialize chat messages with the model property
            var settings = GetJsonSerializerSettings();
            string jsonPayload = JsonConvert.SerializeObject(new { model = "gpt-3.5-turbo", messages = request.Data, temperature = 0.1 }, settings);


            // Send the request
            HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await _httpClient.PostAsync(_apiUrl, content);

            // Deserialize the response
            if (httpResponse.IsSuccessStatusCode)
            {
                string responseJson = await httpResponse.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(responseJson);
                string assistantReply = responseObject.choices[0].message.content;

                request.AddReply(assistantReply);

                response = GPTResponse.Success(request, assistantReply);
            }
            else
            {
                response = GPTResponse.Failure(request, httpResponse.StatusCode.ToString());
            }

            return response;
        }
        public JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };
        }
    }
}
