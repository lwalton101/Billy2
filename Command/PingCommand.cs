using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace BillyTheBot.Command;

public class PingCommand : DiscordCommand
{
    public override async Task HandleCommand(InteractionContext ctx)
    {
        var ping = DateTime.Now - ctx.Interaction.CreationTimestamp;
        Debug.DebugToChannel($"{ctx.User.Username} just ran /ping", DebugLevel.Info);
        await ctx.CreateResponseAsync(new DiscordEmbedBuilder()
            .WithTitle("Pong")
            .WithDescription($"My ping is {ping.Milliseconds}ms"));

        //await Task.CompletedTask;
    }
}