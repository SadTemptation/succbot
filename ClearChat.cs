using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace succBot.Core.Commands
{
    public class ClearChat : ModuleBase
    {
        [Command("clearchat", RunMode = RunMode.Async), Alias("clearchat"), Summary("Clearchat Command - Clears the chat. Usage: =clearchat (amount of messages to be deleted)")]
        public async Task Clearchat(int amount)
        {

            var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();
            await Context.Channel.DeleteMessagesAsync(messages);
            await Context.Channel.SendMessageAsync($"Successfully removed {amount} messages from {Context.Channel.Name}");
        }

    }
}