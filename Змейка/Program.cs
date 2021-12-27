using System;

namespace SnakeGame
{
    class Program
    {
        const int WIDTH = 130;
        const int HEIGHT = 49;
        static void Main(string[] args)
        {

            Game game = new();
            game.StartGame();
        }
    }
}
