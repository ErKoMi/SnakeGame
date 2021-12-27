using System;

namespace dir
{
    class Program
    {
        static void Turn(ref char dir, ref char last_dir)
        {
            if (dir == 'w' && last_dir == 's')
                dir = last_dir;
            if (dir == 's' && last_dir == 'w')
                dir = last_dir;
            if (dir == 'a' && last_dir == 'd')
                dir = last_dir;
            if (dir == 'd' && last_dir == 'a')
                dir = last_dir;
            last_dir = dir;

            Print(dir);
        }

        static void Print(char dir)
        {
            switch (dir)
            {
                case 'w':
                    Console.WriteLine("Вверх");
                    break;
                case 's':
                    Console.WriteLine("Вниз");
                    break;
                case 'a':
                    Console.WriteLine("Влево");
                    break;
                case 'd':
                    Console.WriteLine("Вправо");
                    break;

            }
        }

        static void Main(string[] args)
        {
            char d = 'w', last_d = 'w';
            ConsoleKeyInfo cki;
            do
            {
                while (!Console.KeyAvailable)
                {
                    Turn(ref d, ref last_d);
                    System.Threading.Thread.Sleep(100);
                }
                cki = Console.ReadKey(true);
                d = cki.KeyChar;
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
