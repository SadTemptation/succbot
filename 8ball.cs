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
    public class _8Ball : ModuleBase<SocketCommandContext>
    {

        [Command("8ball "), Alias("8ball"), Summary("8ball command - randomizes your luck")]
        public async Task _8ballembed(params string[] arg)
        {
            string[] eightball;
            Random rnd = new Random();
            eightball = new string []
            {
                "It is certain.",
                "Without a doubt.",
                "Yes, definetly.",
                "Yes.",
                "Reply hazy try again.",
                "?",
                "Bitch, I might be.",
                "idk",
                "No.",
                "Fuck no.",
                "Very doubtful.",
                "My sources say no."
            };
            int eightBallNum = rnd.Next(0, 12);
            await Context.Channel.SendMessageAsync(eightball[eightBallNum]);
        }
    }
}