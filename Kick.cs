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
    public class Kick : ModuleBase<SocketCommandContext>
    {
        [Command("kick"), Alias("kick"), Summary("kicks selected member for a reason")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(GuildPermission.KickMembers)]
        public async Task KickUser(IGuildUser user, string reason = "No reason provided.")
        {
            await user.KickAsync(reason);
            await Context.Channel.SendMessageAsync($"User {user} successfully kicked from {Context.Guild.Name} by {Context.Message.Author}!");
        }

    }

}