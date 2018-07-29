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
    public class Ban : ModuleBase<SocketCommandContext>
    {
        [Command("ban"), Alias("ban"), Summary("bans selected member for a reason")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task BanUser(IGuildUser user, string reason = "No reason provided.")
        {
            await user.Guild.AddBanAsync(user, 5);
        }
    }
}