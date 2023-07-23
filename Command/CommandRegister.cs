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

    [SlashCommand("reloadconfig", "reloads the bots config")]
    public async Task ReloadConfigCommand(InteractionContext ctx)
    {
        await new ReloadConfigCommand().HandleCommand(ctx);
    }

    [SlashCommand("eightball", "Tells you your fate")]
    public async Task EightBallCommand(InteractionContext ctx, [Option("input", "Enter your input")] string input)
    {
        await new EightBallCommand().HandleCommand(ctx, input);
    }
}