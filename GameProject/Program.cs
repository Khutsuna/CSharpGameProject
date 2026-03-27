class Program
{
    static void Main(string[] args)
    {
        Console.WindowHeight = 50;
        Console.WindowWidth = 140;

        GameProject.Core.Game game = new GameProject.Core.Game();
        game.Start();
    }
}