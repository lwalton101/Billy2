using DSharpPlus.SlashCommands;

namespace BillyTheBot.Command;

public class CommandRegister : ApplicationCommandModule
{
    [SlashCommand("ping", "Pings the bot. is a bit pongy")]
    public async Task PingCommand(InteractionContext ctx)
    {
        await new PingCommand().HandleCommand(ctx);
    }
}