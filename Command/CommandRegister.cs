using DSharpPlus.SlashCommands;

namespace BillyTheBot.Command;

public class CommandRegister : ApplicationCommandModule
{
    [SlashCommand("ping", "Pings the bot. is a bit pongy")]
    public async Task PingCommand(InteractionContext ctx)
    {
        await new PingCommand().HandleCommand(ctx);
    }

    [SlashCommand("lie", "None of this is true")]
    public async Task LieCommand(InteractionContext ctx)
    {
        await new LieCommand().HandleCommand(ctx);
    }
}