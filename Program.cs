using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace succBot
{
    class Program
    {

        private DiscordSocketClient client;
        private CommandService commands;

        static void Main(string[] args)
            => new Program().aSync().GetAwaiter().GetResult();

        private async Task aSync()
        {
            client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug
            });

            commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = false,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });
            client.MessageReceived += client_MessageReceived;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly());

            client.Ready += client_Ready;
            client.Log += client_Log;

            string Token = "NDcyNzUwODMzMDMzODA1ODM0.Dj5sXw.AFjjXLYQvvAoOqlSe_a7UuDQXV8";

            await client.LoginAsync(TokenType.Bot, Token);
            await client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task client_Log(LogMessage message)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"{message.Source}] - {message.Message}");
            Console.WriteLine("---------------------------------------");
        }

        private async Task client_Ready()
        {
            await client.SetGameAsync("with some plumbus");
        }

        private async Task client_MessageReceived(SocketMessage messageParam)
        {

            var message = messageParam as SocketUserMessage;
            var succ = new SocketCommandContext(client, message);

            if (succ.Message == null || succ.Message.Content == "") return;
            if (succ.User.IsBot) return;

            int argPos = 0;
            if (!(message.HasStringPrefix("=", ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))) return;

            var result = await commands.ExecuteAsync(succ, argPos);
            if (!result.IsSuccess)
                Console.WriteLine($"{message.Source}] - Something went wrong with your command. Text: '{succ.Message.Content}' - Error Code: {result.ErrorReason} ");
        }

    }
}
