using BillyTheBot.API.EightBall;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace BillyTheBot.Command;

public class EightBallCommand : DiscordCommand
{
    public async Task HandleCommand(InteractionContext ctx, string input)
    {
        Debug.DebugToChannel($"{ctx.User.Username} just ran /eightball", DebugLevel.Info);

        var outcome = await EightBallAPI.GetReading();
        var des = $"{input}\n*8 Ball Says...*\n{outcome}";

        await ctx.CreateResponseAsync(new DiscordEmbedBuilder()
            .WithTitle("You said")
            .WithDescription(des)
            .WithColor(DiscordColor.Black));
    }

    public override async Task HandleCommand(InteractionContext ctx)
    {
        await HandleCommand(ctx, "AHHH WTF NO INPUT?????");
    }
}