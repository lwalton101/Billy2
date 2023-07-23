using DSharpPlus.SlashCommands;

namespace BillyTheBot.Command;

public abstract class DiscordCommand
{
    public abstract Task HandleCommand(InteractionContext ctx);
}