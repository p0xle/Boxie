using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxie
{
    public class BoxieCore
    {
        private readonly DiscordSocketClient _client = new();
        private readonly Config Config = LoadConfig();

        public async Task MainAsync()
        {
            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, Config.Token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private static Config LoadConfig(string filePath = "config.json")
        {
            try
            {
                var fileContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Config>(fileContent) ?? new Config();
            }
            catch (Exception)
            {
                Console.WriteLine("Error loading Config");
                throw;
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
