using System;

namespace Draw
{
    class Program
    {

        static void Draw(Tuple <int, int> position, char simbol, string color = "white")
        {
            switch (color)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }
            Console.SetCursorPosition(position.Item2, position.Item1);
            Console.Write(simbol);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Field()
        {
            for (int i = 0; i < 100; i++)
            {
                Draw(new Tuple <int, int>( 40, i ), '■', "red");
            }
            for (int i = 0; i < 41; i++)
            {
                Draw(new Tuple<int, int> (i, 100 ), '■', "red");
            }
            Tuple <int, int> [] С = new Tuple<int, int>[9] 
            {
            new Tuple <int, int> (6, 110),
            new Tuple<int, int> (6, 109),
            new Tuple<int, int> (6, 108),
            new int[2] {7, 108},
            new int[2] {8, 108},
            new int[2] {9, 108},
            new int[2] {10, 108},
            new int[2] {10, 109},
            new int[2] {10, 110},
            };
            int[][] Ч = new int[9][]
            {
            new int[2] {6, 112},
            new int[2] {7, 112},
            new int[2] {8, 112},
            new int[2] {8, 113},
            new int[2] {8, 114},
            new int[2] {6, 114},
            new int[2] {7, 114},
            new int[2] {9, 114},
            new int[2] {10, 114},
            };
            foreach (int[] point in С)
            {
                Draw(point, '#', "yellow");
            }
            foreach (int[] point in Ч)
            {
                Draw(point, '#', "yellow");
            }
        }

        static void Main(string[] args)
        {
            const int WIDTH = 150;
            const int HEIGTH = 45;
            Console.WindowWidth = WIDTH;
            Console.BufferWidth = Console.WindowWidth;
            Console.WindowHeight = HEIGTH;
            Console.BufferHeight = Console.WindowHeight;

            Field();


            Console.ReadKey(true);
        }
    }
}
