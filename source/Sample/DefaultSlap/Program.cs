namespace DefaultSlap
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DefaultGame game = new DefaultGame())
            {
                game.Run();
            }
        }
    }
}
