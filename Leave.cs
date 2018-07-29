using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace succ
{
    public class Leave : ModuleBase<SocketCommandContext>
    {
        [Command("leave"), Alias("leave"), Summary("leaves the server for the member")]
        [RequireBotPermission(GuildPermission.KickMembers)]
        
        public async Task Leaves(IGuildUser user, string reason = "")
        {
         
            await user.KickAsync(reason);
            await Context.Channel.SendMessageAsync($"{Context.Message.Author} left the server!");
        }

    }

}