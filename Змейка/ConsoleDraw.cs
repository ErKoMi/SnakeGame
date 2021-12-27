using System;


namespace SnakeGame
{
    public class ConsoleDraw
    {

        private static readonly Tuple<int, int>[][] words =
        {
            new Tuple<int, int>[]
            {
            new(2, 0),
            new(2, 1),
            new(1, 2),
            new(1, 3),
            new(0, 4),
            new(3, 2),
            new(3, 3),
            new(4, 4),
            new(2, 3)
            }, //а
            new Tuple<int, int>[]
            {
            new(0, 0),
            new(0, 1),
            new(0, 2),
            new(0, 3),
            new(0, 4),
            new(1, 0),
            new(2, 0),
            new(2, 1),
            new(2, 2),
            new(1, 2)
            }, //р
            new Tuple<int, int>[]
            {
            new Tuple<int, int> (0, 0),
            new Tuple <int, int> (0, 1),
            new Tuple <int, int> (0, 2),
            new Tuple <int, int> (0, 3),
            new Tuple <int, int> (0, 4),
            new(1, 2),
            new(2, 1),
            new(3, 0),
            new(2, 3),
            new(3, 4)
            }, //к
            new Tuple<int, int>[]
            {
            new Tuple <int, int> (0, 0),
            new Tuple<int, int> (0, 1),
            new Tuple<int, int> (0, 2),
            new Tuple <int, int> (0, 3),
            new Tuple <int, int> (0, 4),
            new Tuple <int, int> (2, 0),
            new Tuple<int, int> (2, 1),
            new Tuple<int, int> (2, 2),
            new Tuple <int, int> (2, 3),
            new Tuple <int, int> (2, 4),
            new Tuple <int, int> (1, 0),
            new Tuple<int, int> (1, 4)
            }, //о
            new Tuple<int, int>[]
            {
                new(2, 0),
                new(1, 1),
                new(1, 2),
                new(3, 1),
                new(3, 2),
                new(2, 2),
                new(0, 3),
                new(0, 4),
                new(4, 3),
                new(4, 4),
                new(1, 0),
                new(3, 0)
            }, //д
            new Tuple<int, int>[]
            {
            new Tuple <int, int> (2, 0),
            new Tuple<int, int> (1, 0),
            new Tuple<int, int> (0, 0),
            new Tuple <int, int> (0, 1),
            new Tuple <int, int> (0, 2),
            new Tuple <int, int> (0, 3),
            new Tuple <int, int> (0, 4),
            new Tuple <int, int> (1, 4),
            new Tuple <int, int> (2, 4),
            }, //с
            new Tuple<int, int>[]
            {
                new Tuple <int, int> (0, 0),
                new Tuple<int, int> (0, 1),
                new Tuple<int, int> (0, 2),
                new Tuple <int, int> (1, 2),
                new Tuple <int, int> (2, 0),
                new Tuple <int, int> (2, 1),
                new Tuple <int, int> (2, 2),
                new Tuple <int, int> (2, 3),
                new Tuple <int, int> (2, 4)
            }, //ч
            new Tuple<int, int>[]
            {
                new Tuple <int, int> (0, 0),
                new Tuple<int, int> (0, 1),
                new Tuple<int, int> (0, 2),
                new Tuple <int, int> (0, 3),
                new Tuple <int, int> (0, 4),
                new Tuple <int, int> (1, 0),
                new Tuple <int, int> (1, 2),
                new Tuple <int, int> (1, 4),
                new Tuple <int, int> (2, 0),
                new Tuple <int, int> (2, 2),
                new Tuple <int, int> (2, 4),
            }, //е
            new Tuple<int, int>[]
            {
                new Tuple <int, int> (1, 0),
                new Tuple<int, int> (1, 1),
                new Tuple<int, int> (1, 2),
                new Tuple <int, int> (1, 3),
                new Tuple <int, int> (1, 4),
                new Tuple <int, int> (0, 0),
                new Tuple <int, int> (2, 0)
            }, //т
            new Tuple<int, int>[]
            {
                new(0, 0),
                new(0, 1),
                new(0, 2),
                new(0, 3),
                new(0, 4),
                new(1, 0),
                new(2, 0),
                new(2, 1),
                new(2, 2),
                new(2, 3),
                new(2, 4)

            }, //п
            new Tuple<int, int>[]
            {
                new(0, 0),
                new(0, 1),
                new(0, 2),
                new(0, 3),
                new(0, 4),
                new(1, 2),
                new(2, 0),
                new(2, 1),
                new(2, 2),
                new(2, 3),
                new(2, 4)
            }, //н
            new Tuple<int, int>[]
            {
                new(0, 0),
                new(0, 1),
                new(0, 2),
                new(0, 3),
                new(0, 4),
                new(1, 4),
                new(2, 0),
                new(2, 1),
                new(2, 2),
                new(2, 3),
                new(2, 4),
                new(2, 5)
            }, //ц
            new Tuple<int, int>[]
            {
                new(0,0),
                new(0,1),
                new(2,0),
                new(2,1),
                new(1,2),
                new(1,3),
                new(0,4)
            }, //у
            new Tuple<int, int>[]
            {
                new(0, 0),
                new(0, 2),
                new(0, 4),
                new (2, 0),
                new(2, 1),
                new(2, 2),
                new (2, 3),
                new (2, 4),
                new (1, 0),
                new(1, 4),
                new(1, 2)
            }, //з
            //Большие буквы для заставки
            new Tuple<int, int>[]
            {
                new(0,0),
                new(1,0),
                new(2,0),
                new(3,0),
                new(2,1),
                new(1,2),
                new(0,3),
                new(1,3),
                new(2,3),
                new(3,3),
                new(3,4),
                new(3,5),
                new(3,6),
                new(2,6),
                new(1,6),
                new(0,6)
            }, //З
            new Tuple<int, int>[]
            {
                new(0, 0),
                new(0, 1),
                new(0, 2),
                new(0, 3),
                new(0, 4),
                new(0, 5),
                new(0, 6),
                new(5, 0),
                new(5, 1),
                new(5, 2),
                new(5, 3),
                new(5, 4),
                new(5, 5),
                new(5, 6),
                new(1, 1),
                new(2, 2),
                new(3, 2),
                new(4, 1)
            }, //М
            new Tuple<int, int>[]
            {
                new(0, 0),
                new(0, 1),
                new(0, 2),
                new(0, 3),
                new(0, 4),
                new(0, 5),
                new(0, 6),
                new(1, 0),
                new(2, 0),
                new(3, 0),
                new(1, 3),
                new(2, 3),
                new(3, 3),
                new(1, 6),
                new(2, 6),
                new(3, 6)
            }, //Е
            new Tuple<int, int>[]
            {
                new(0, 0),
                new(0, 1),
                new(0, 2),
                new(0, 3),
                new(0, 4),
                new(0, 5),
                new(0, 6),
                new(4, 0),
                new(4, 1),
                new(4, 2),
                new(4, 3),
                new(4, 4),
                new(4, 5),
                new(4, 6),
                new(1, 4),
                new(2, 3),
                new(3, 2),
                new(2, 0)
            }, //Й
            new Tuple<int, int>[]
            {
                new(0, 0),
                new(0, 1),
                new(0, 2),
                new(0, 3),
                new(0, 4),
                new(0, 5),
                new(0, 6),
                new(1, 3),
                new(2, 2),
                new(3, 1),
                new(4, 0),
                new(2, 4),
                new(3, 5),
                new(4, 6)
            }, //К
            new Tuple<int, int>[]
            {
                new(3, 0),
                new(3, 1),
                new(2, 2),
                new(2, 3),
                new(1, 4),
                new(1, 5),
                new(0, 6),
                new(4, 2),
                new(4, 3),
                new(5, 4),
                new(5, 5),
                new(6, 6),
                new(1, 4),
                new(2, 4),
                new(3, 4),
                new(4, 4)
            } //А
        };
        /// <summary>
        /// Буквы, доступные для отрисовки
        /// </summary>
        public enum Alphabet
        {
            А, Р, К, О, Д, С, Ч, Е, Т, П, Н, Ц, У, З, Зbig, Mbig, Еbig, Йbig, Кbig, Аbig,
        }
        /// <summary>
        /// Координаты для отрисовки буквы без смещения
        /// </summary>
        /// <param name="w">Название буквы типа Alphabet</param>
        /// <returns>Массив с кортежами типа (x,y)</returns>
        public static Tuple<int, int>[] GetWord(Alphabet w)
        {
            return words[(int)w];
        }


        private static readonly Tuple<int, int>[][] numbers =
        {
            new Tuple<int, int>[12]
            {
            new Tuple <int, int> (0, 0),
            new Tuple<int, int> (0, 1),
            new Tuple<int, int> (0, 2),
            new Tuple <int, int> (0, 3),
            new Tuple <int, int> (0, 4),
            new Tuple <int, int> (2, 0),
            new Tuple<int, int> (2, 1),
            new Tuple<int, int> (2, 2),
            new Tuple <int, int> (2, 3),
            new Tuple <int, int> (2, 4),
            new Tuple <int, int> (1, 0),
            new Tuple<int, int> (1, 4)
            },
            new Tuple<int, int>[5]
            {
            new Tuple <int, int> (2, 0),
            new Tuple<int, int> (2, 1),
            new Tuple<int, int> (2, 2),
            new Tuple <int, int> (2, 3),
            new Tuple <int, int> (2, 4),
            },
            new Tuple<int, int>[11]
            {
                new Tuple <int, int> (0, 0),
                new Tuple<int, int> (0, 2),
                new Tuple <int, int> (0, 3),
                new Tuple <int, int> (0, 4),
                new Tuple <int, int> (2, 0),
                new Tuple<int, int> (2, 1),
                new Tuple<int, int> (2, 2),
                new Tuple <int, int> (2, 4),
                new Tuple <int, int> (1, 0),
                new Tuple<int, int> (1, 4),
                new Tuple<int, int> (1, 2)
            },
            new Tuple<int, int>[11]
            {
                new Tuple <int, int> (0, 0),
                new Tuple<int, int> (0, 2),
                new Tuple <int, int> (0, 4),
                new Tuple <int, int> (2, 0),
                new Tuple<int, int> (2, 1),
                new Tuple<int, int> (2, 2),
                new Tuple <int, int> (2, 3),
                new Tuple <int, int> (2, 4),
                new Tuple <int, int> (1, 0),
                new Tuple<int, int> (1, 4),
                new Tuple<int, int> (1, 2)
            },
            new Tuple<int, int>[9]
            {
            new Tuple <int, int> (0, 0),
            new Tuple<int, int> (0, 1),
            new Tuple<int, int> (0, 2),
            new Tuple<int, int> (2, 0),
            new Tuple<int, int> (2, 1),
            new Tuple<int, int> (2, 2),
            new Tuple <int, int> (2, 3),
            new Tuple <int, int> (2, 4),
             new Tuple<int, int> (1, 2)
            },
            new Tuple<int, int>[11]
            {
                new Tuple <int, int> (0, 0),
                new Tuple<int, int> (0, 1),
                new Tuple<int, int> (0, 2),
                new Tuple <int, int> (0, 4),
                new Tuple <int, int> (2, 0),
                new Tuple<int, int> (2, 2),
                new Tuple <int, int> (2, 3),
                new Tuple <int, int> (2, 4),
                new Tuple <int, int> (1, 0),
                new Tuple<int, int> (1, 4),
                new Tuple<int, int> (1, 2)
            },
            new Tuple<int, int>[12]
            {
                new Tuple <int, int> (0, 0),
                new Tuple<int, int> (0, 1),
                new Tuple<int, int> (0, 2),
                new Tuple<int, int> (0, 3),
                new Tuple <int, int> (0, 4),
                new Tuple <int, int> (2, 0),
                new Tuple<int, int> (2, 2),
                new Tuple <int, int> (2, 3),
                new Tuple <int, int> (2, 4),
                new Tuple <int, int> (1, 0),
                new Tuple<int, int> (1, 4),
                new Tuple<int, int> (1, 2)
            },
            new Tuple<int, int>[7]
            {
                new Tuple <int, int> (0, 0),
                new Tuple <int, int> (2, 0),
                new Tuple<int, int> (2, 1),
                new Tuple<int, int> (2, 2),
                new Tuple <int, int> (2, 3),
                new Tuple <int, int> (2, 4),
                new Tuple <int, int> (1, 0),
            },
            new Tuple<int, int>[13]
            {
                new Tuple <int, int> (0, 0),
                new Tuple<int, int> (0, 1),
                new Tuple<int, int> (0, 2),
                new Tuple <int, int> (0, 3),
                new Tuple <int, int> (0, 4),
                new Tuple <int, int> (2, 0),
                new Tuple<int, int> (2, 1),
                new Tuple<int, int> (2, 2),
                new Tuple <int, int> (2, 3),
                new Tuple <int, int> (2, 4),
                new Tuple <int, int> (1, 0),
                new Tuple<int, int> (1, 2),
                new Tuple<int, int> (1, 4)
            },
            new Tuple<int, int>[12]
            {
                new Tuple <int, int> (0, 0),
                new Tuple<int, int> (0, 1),
                new Tuple<int, int> (0, 2),
                new Tuple <int, int> (0, 4),
                new Tuple <int, int> (2, 0),
                new Tuple<int, int> (2, 1),
                new Tuple<int, int> (2, 2),
                new Tuple <int, int> (2, 3),
                new Tuple <int, int> (2, 4),
                new Tuple <int, int> (1, 0),
                new Tuple<int, int> (1, 4),
                new Tuple<int, int> (1, 2)
            },
        };
        /// <summary>
        /// Цифры, доступные для отрисовки
        /// </summary>
        public enum Numbers
        {
            ZERO, ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE
        }
        /// <summary>
        /// Координаты для отрисовки цифры без смещения
        /// </summary>
        /// <param name="w">Название цифры из перечисления Numbers </param>
        /// <returns>Массив с кортежами типа (x,y)</returns>
        public static Tuple <int, int>[] GetNumber(Numbers n)
        {
            return numbers[(int)n];
        }

        
        public static void Print(Tuple<int, int> point, string simbol, ConsoleColor color = ConsoleColor.White, int offset_X = 0, int offset_y = 0)
        {
            Console.ForegroundColor = color;
            Console.CursorVisible = false;
            Console.SetCursorPosition(point.Item1 + offset_X, point.Item2 + offset_y);
            Console.Write(simbol);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Clear(Tuple<int, int> point, int offset_x = 0, int offset_y = 0)
        {
            Console.SetCursorPosition(point.Item1 + offset_x, point.Item2 + offset_y);
            Console.Write(' ');
        }

        public static void Print(string s, int offset_X, int offset_y, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.CursorVisible = false;
            Console.SetCursorPosition(offset_X, offset_y);
            Console.WriteLine(s);
        }
        public static void CPrint(string s, int offset_X, int offset_y, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.CursorVisible = false;
            Console.SetCursorPosition(offset_X - s.Length / 2, offset_y);
            Console.WriteLine(s);
        }
        public static void Clear(string s, int offset_X, int offset_y)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(offset_X, offset_y);
            Console.WriteLine(new string(' ', s.Length));
        }
        public static void CClear(string s, int offset_X, int offset_y)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(offset_X -s.Length/2, offset_y);
            Console.WriteLine(new string(' ', s.Length));
        }

        public static void PrintDigit(Numbers n, int off_x, int off_y, string simbol, ConsoleColor color = ConsoleColor.White)
        {
            foreach(Tuple <int,int> point in GetNumber(n))
            {
                Print(point, simbol, color, off_x, off_y);
            }
        }
        public static void ClearDigit(Numbers n, int off_x, int off_y)
        {
            foreach(Tuple<int,int> point in GetNumber(n))
            {
                Clear(point, off_x, off_y);
            }
        }
        public static void PrintNumber(Numbers[] n, int off_x, int off_y, string simbol, ConsoleColor color = ConsoleColor.White)
        {
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] == Numbers.ZERO)
                {
                    Clear(new Tuple<int, int>(off_x + i * 4 + 1, off_y + 2));
                }
                PrintDigit(n[i], off_x + i * 4, off_y, simbol, color);
            }
        }
        public static void PrintLetter(Alphabet w, int off_x, int off_y, string simbol, ConsoleColor color = ConsoleColor.White)
        {
            foreach (Tuple<int, int> point in GetWord(w))
            {
                Print(point, simbol, color, off_x, off_y);
            }
        }
        public static void PrintWord(Alphabet[] w, int off_x, int off_y, string simbol, ConsoleColor color = ConsoleColor.White)
        {
            int offset = off_x;
            for (int i = 0; i < w.Length; i++)
            {
                PrintLetter(w[i], offset, off_y, simbol, color);
            }
        }
        public static void ClearWord(Alphabet w, int off_x, int off_y)
        {
            foreach(Tuple <int,int> point in GetWord(w))
            {
                Clear(point, off_x, off_y);
            }
        }

    }
}
