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

    public static void DebugToChannel(string content, DebugLevel level)
    {
        DebugToChannel(content, level, $"Debug Level {level}");
    }

    public static void DebugToChannel(string content, DebugLevel level, string title)
    {
        var color = DebugLevelToColor(level);
        var message = new DiscordEmbedBuilder()
            .WithColor(color)
            .WithTitle(title)
            .WithDescription(content);

        DebugChannel.SendMessageAsync(message);
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
        }

        return DiscordColor.Blurple;
    }
}