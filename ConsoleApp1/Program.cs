using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    Console.Write("{0}\t", j);
                }
                Console.WriteLine();
            }
        }
    }
}
