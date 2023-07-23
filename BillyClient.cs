using BillyTheBot.Command;
using BillyTheBot.Exceptions;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;

namespace BillyTheBot;

public class BillyClient
{
    private readonly string _token;
    private DiscordClient _client = null!;

    public BillyClient(string token)
    {
        _token = token;
    }

    public async Task RunAsync()
    {
        if (_token == "") throw new TokenNotSetException();
        _client = new DiscordClient(new DiscordConfiguration
        {
            Token = _token,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All
        });
        _client.GuildDownloadCompleted += OnGuildConnect;
        var slash = _client.UseSlashCommands();
        slash.RegisterCommands<CommandRegister>(1131949379813638216);

        await _client.ConnectAsync();
        await Task.Delay(-1);
    }

    private Task OnGuildConnect(DiscordClient sender, GuildDownloadCompletedEventArgs args)
    {
        Debug.DebugChannel = _client.Guilds[1131949379813638216].Channels[1132604508443258910];
        Console.WriteLine("Connected to discord in these guilds: ");
        foreach (var guild in args.Guilds.Values)
        {
            Console.WriteLine($"{guild.Name} : {guild.Members.Count} people");
        }

        Debug.DebugToChannel("Billy is turned on!", DebugLevel.Info);

        return Task.CompletedTask;
    }
}