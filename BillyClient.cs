using BillyTheBot.Exceptions;
using Discord;
using Discord.WebSocket;

namespace BillyTheBot;

public class BillyClient
{
    private readonly string _token;
    private DiscordSocketClient _client = null!;

    public BillyClient(string token)
    {
        _token = token;
    }

    public async Task RunAsync()
    {
        if (_token == "") throw new TokenNotSetException();

        _client = new DiscordSocketClient();
        _client.Log += OnClientLog;

        await _client.LoginAsync(TokenType.Bot, _token);
        await _client.StartAsync();


        await Task.Delay(-1);
    }

    private Task OnClientLog(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}