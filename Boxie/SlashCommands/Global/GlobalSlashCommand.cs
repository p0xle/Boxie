﻿using Boxie.Services.Logging;
using Boxie.SlashCommands.Global.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Boxie.SlashCommands.Global
{
    public abstract class GlobalSlashCommand : SlashCommandBase
    {
        public GlobalSlashCommand(string name, string description, IServiceProvider serviceProvider, ILoggingService loggingService) : base(name, description, serviceProvider, loggingService)
        {
        }

        public override async Task CreateAsync()
        {
            try
            {
                IGlobalSlashCommandFactory testCommandFactory = _serviceProvider.GetRequiredService<IGlobalSlashCommandFactory>();
                SlashCommandStorage slashCommands = _serviceProvider.GetRequiredService<SlashCommandStorage>();

                if (await testCommandFactory.CreateAsync(Name, Description))
                {
                    slashCommands.Add(this);
                }
            }
            catch (Exception ex)
            {
                await _loggingService.LogAsync(ex.Message, LogLevel.Error);
            }
        }
    }
}