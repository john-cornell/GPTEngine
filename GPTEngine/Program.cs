﻿// See: https://platform.openai.com/docs/guides/chat/introduction
// See: https://platform.openai.com/docs/api-reference/chat
using GPTEngine;
using GPTEngine.Roles;
using GPTEngine.Roles.Types;
using System;

GPT gpt = new GPT();

RoleBehaviour behaviour = new GiftedSongwriter();
Conversation architectConversation = new Conversation(
    behaviour.As(RoleType.System),
    behaviour.As(RoleType.Assistant),
    false
);

do
{
    await Console.Out.WriteAsync(">");
    string request = Console.ReadLine().Trim();

    if (request.ToLower() == "x" || request.ToLower() == "exit" || request.ToLower() == "quit")
    {
        return;
    }
    else if (!string.IsNullOrWhiteSpace(request))
    {
        architectConversation.AddMessage(request);
        GPTResponse response = await gpt.Call(architectConversation);

        await Console.Out.WriteLineAsync(response.IsError ? response.Error : response.Response);
    }
}
while (true);