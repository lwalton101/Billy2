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

        await ctx.CreateResponseAsync(outcome.Replace("%name", name));
    }
}