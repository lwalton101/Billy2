using DSharpPlus.Entities;

namespace BillyTheBot;

public class Debug
{
    private static DiscordChannel _debugChannel = null!;

    public static DiscordChannel DebugChannel
    {
        get => _debugChannel;
        set
        {
            Console.WriteLine($"Debugging to channel {value.Name}");
            _debugChannel = value;
        }
    }

    public static async Task DebugToChannel(string content, DebugLevel level)
    {
        await DebugToChannel(content, level, $"Debug Level {level}");
    }

    public static async Task DebugToChannel(string content, DebugLevel level, string title)
    {
        var color = DebugLevelToColor(level);
        var message = new DiscordEmbedBuilder()
            .WithColor(color)
            .WithTitle(title)
            .WithDescription(content);

        await DebugChannel.SendMessageAsync(message);
    }

    private static DiscordColor DebugLevelToColor(DebugLevel debugLevel)
    {
        switch (debugLevel)
        {
            case DebugLevel.Info:
                return DiscordColor.White;
            case DebugLevel.Warn:
                return DiscordColor.Yellow;
            case DebugLevel.Error:
                return DiscordColor.DarkRed;
            default:
                throw new ArgumentOutOfRangeException(nameof(debugLevel), debugLevel, null);
        }

        return DiscordColor.Blurple;
    }

    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}