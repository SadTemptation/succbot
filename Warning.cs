using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using succ.Core.UserAccounts;
using System.Net;
using Newtonsoft.Json;
using Discord.Rest;

namespace succ
{
    public class Warning : ModuleBase<SocketCommandContext>
    {
        [Command("warn")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task WarnUser(IGuildUser user)
        {
            var userAccount = UserAccounts.GetAccount((SocketUser)user);
            userAccount.NumberOfWarnings++;
            UserAccounts.SaveAccounts();

            if (userAccount.NumberOfWarnings >= 3)
            {
                await user.Guild.AddBanAsync(user, 5);
            }
            else if (userAccount.NumberOfWarnings == 2)
            {
                await Context.Channel.SendMessageAsync($"{userAccount} has been Warned. Number of Warnings: {userAccount.NumberOfWarnings}");
            }
            else if (userAccount.NumberOfWarnings <= 1)
            {
                await Context.Channel.SendMessageAsync($"{userAccount} has been Warned. Number of Warnings: {userAccount.NumberOfWarnings}");
            }
        }
    }
}