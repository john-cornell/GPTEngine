using GPTEngine.Roles;

namespace GPTEngine
{
    public class Conversation
    {
        List<GPTMessage> _messages;

        public Conversation(Role system, Role assistant)
        {
            if (system.RoleType != RoleType.System)
            {
                throw new ArgumentException("The first role must be of type System.", nameof(system));
            }

            if (assistant.RoleType != RoleType.Assistant)
            {
                throw new ArgumentException("The second role must be of type Assistant.", nameof(assistant));
            }

            _messages = new List<GPTMessage>() { system.GetSetupMessage(), assistant.GetSetupMessage() };
        }

        public void AddMessage(string message)
        {
            _messages.Add(new GPTMessage("user", message));
        }

        public void AddReply(string message)
        {
            _messages.Add(new GPTMessage("assistant", message));
        }

        public GPTMessage[] Data => _messages.ToArray();
    }

}
