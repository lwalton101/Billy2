using BillyTheBot.Extension;
using DSharpPlus.SlashCommands;

namespace BillyTheBot.Command;

public class LieCommand : DiscordCommand
{
    public override async Task HandleCommand(InteractionContext ctx)
    {
        Debug.DebugToChannel($"{ctx.User.Username} just ran /lie", DebugLevel.Info);
        var rng = new Random();
        var name = Config.Names.ChooseRandom(rng);
        var outcome = Config.Events.ChooseRandom(rng);

        //var message = await ctx.FollowUpAsync(new DiscordFollowupMessageBuilder().WithContent(outcome.Replace("%name", name)));
        await ctx.CreateResponseAsync(outcome.Replace("%name", name));
    }
}