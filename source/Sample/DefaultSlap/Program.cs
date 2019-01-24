namespace DefaultSlap
{
    internal static class Program
    {
        private static void Main()
        {
            using (DefaultGame game = new DefaultGame())
            {
                game.Run();
            }
        }
    }
}
