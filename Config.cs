namespace BillyTheBot;

public static class Config
{
    private const string TokenPath = "token.txt";
    private const string NamesPath = "names.txt";
    private const string EventsPath = "events.txt";
    public static string Token { get; private set; } = "";
    public static List<String> Names { get; private set; } = new();
    public static List<String> Events { get; private set; } = new();

    public static void InitConfig()
    {
        CreateFileIfDoesntExist(TokenPath);
        CreateFileIfDoesntExist(NamesPath);
        CreateFileIfDoesntExist(EventsPath);

        Token = File.ReadAllText(TokenPath);
        Names = File.ReadAllLines(NamesPath).ToList();
        Events = File.ReadAllLines(EventsPath).ToList();
    }

    private static void CreateFileIfDoesntExist(string filePath)
    {
        if (File.Exists(filePath)) return;
        File.Create(filePath).Close();

        Debug.Error($"File {filePath} didn't exist. Has been created");
    }
}