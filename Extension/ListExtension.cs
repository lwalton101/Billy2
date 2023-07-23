namespace BillyTheBot.Extension;

public static class ListExtension
{
    public static T ChooseRandom<T>(this List<T> list, Random rng)
    {
        return list[rng.Next(0, list.Count)];
    }
}