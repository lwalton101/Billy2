using DSharpPlus.SlashCommands;

namespace BillyTheBot.Command;

public class ReloadConfigCommand : DiscordCommand
{
    public override async Task HandleCommand(InteractionContext ctx)
    {
        Debug.DebugToChannel($"{ctx.User.Username} just ran /reloadconfig", DebugLevel.Info);
        if (ctx.User.Id == 545350139003273238)
        {
            Config.InitConfig();
            await ctx.CreateResponseAsync("Config Reloaded!", true);
        }
        else
        {
            await ctx.CreateResponseAsync("You do not have permission to do this", true);
        }
    }
}