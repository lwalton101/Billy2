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
        var name2 = Config.Names.ChooseRandom(rng);
        var outcome = Config.Events.ChooseRandom(rng);
        var message = outcome.Replace("%name", name).Replace("%2", name2).Replace("%new", "\n");
        await ctx.CreateResponseAsync(message);
    }
}