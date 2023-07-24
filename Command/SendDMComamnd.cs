using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace BillyTheBot.Command;

public class SendDMComamnd : DiscordCommand
{
    public async Task HandleCommand(InteractionContext ctx, DiscordUser? user, string message)
    {
        if (user == null!)
        {
            await Debug.DebugToChannel("DiscordUser is null for some reason", DebugLevel.Error);
            await ctx.CreateResponseAsync("Something went wrong");
        }

        await Debug.DebugToChannel($"{ctx.User.Username} just sent \"{message}\" to {user.Username}", DebugLevel.Info);
        await (user as DiscordMember)?.SendMessageAsync(message)!;
        await ctx.CreateResponseAsync($"DM Sent to {user.Username}");
    }

    public override async Task HandleCommand(InteractionContext ctx)
    {
        await HandleCommand(ctx, null, "Balls");
    }
}