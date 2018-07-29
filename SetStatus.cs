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
    public class SetStatus : ModuleBase<SocketCommandContext>
    {
        [Command("setgame"), Alias("setgame"), Summary("setgame Command - Sets the playing status of the bot"), RequireUserPermission(GuildPermission.Administrator)]
        public async Task SetStatusCommand([Summary("game")]params string[] arg)
        {

            string argText = string.Join(" ", arg);
            await Context.Client.SetGameAsync(argText);
            await Context.Channel.SendMessageAsync($"Bot's playing status set successfully to: {argText}!");
        }
    }
}
