# Boxie

Discord Bot using the [Discord.Net Framework](https://discordnet.dev/)

Setup:
- Create a copy of the template.config.json file and name it 'config.json'
- Fill the token field with your own discord application token

The bot registers all slash commands on startup. Guild Commands are instantly created / updated, while Global Commands need up to an hour.

To create Guild Slash Commands on Startup you need to enter your GuildID in the config.\
You can get that ID by enabling Developer Mode in the Advanced Discord Settings, then right clicking a server and selecting "Copy Server ID"

If you want to delete all Global or Guild Slash Commands on Startup you can do that by setting the corresponding field in the config.

You can disable certain Slash Commands by passing in `isDisabled: true` into the base constructor.\
❗Keep in mind that if that users can still see the command, if it was previously registered❗

Currently implemented functioning Global Commands
- /free-epic-games (Returning free games for this and the upcoming week. currently in german with no language support)
