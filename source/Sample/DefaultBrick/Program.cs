namespace DefaultBrick
{
    internal static class Program
    {
        private static void Main()
        {
            using DefaultGame game = new();

            game.Run();
        }
    }
}
