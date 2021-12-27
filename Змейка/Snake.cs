using System;
using System.Threading;

namespace SnakeGame
{
    class Snake
    {
        private Tuple<int, int>[] SnakeCoords { get; set; }
        private string BodySimbol { get; set; }
        private string HeadSimbol { get; set; }
        private ConsoleColor BodyColor { get; set; }
        private ConsoleColor HeadColor { get; set; }
        public Tuple<int, int>[] Coords { get => SnakeCoords;}

        public Snake(Tuple<int, int>[] snakeCoords, string bodySimbol, string headSimbol, ConsoleColor bodyColor, ConsoleColor headColor)
        {
            SnakeCoords = snakeCoords;
            BodySimbol = bodySimbol;
            HeadSimbol = headSimbol;
            BodyColor = bodyColor;
            HeadColor = headColor;
        }

        public void Append(Tuple <int, int> point)
        {
            Tuple<int, int>[] temp = SnakeCoords;
            ConsoleDraw.Print(temp[^1], BodySimbol, BodyColor);
            Array.Resize(ref temp, temp.Length + 1);
            temp[^1] = point;
            ConsoleDraw.Print(point, HeadSimbol, HeadColor);
            SnakeCoords = temp;
        }

        public bool Move(Tuple <int, int> point)
        {

            foreach (Tuple<int,int> body_point in Coords)
            {
                if(point.Item1 == body_point.Item1 && point.Item2 == body_point.Item2)
                {
                    return false;
                }
            }
            ConsoleDraw.Print(SnakeCoords[^1], BodySimbol, BodyColor);
            ConsoleDraw.Clear(SnakeCoords[0]);
            for (int i = 0; i < SnakeCoords.Length - 1; i++)
            {
                SnakeCoords[i] = SnakeCoords[i + 1];
            }
            SnakeCoords[^1] = point;
            ConsoleDraw.Print(point, HeadSimbol, HeadColor);
            return true;
        }

        public void DrawFull()
        {
            for(int i = 0; i < SnakeCoords.Length - 1; i++)
            {
                ConsoleDraw.Print(SnakeCoords[i], BodySimbol, BodyColor);
            }
            ConsoleDraw.Print(SnakeCoords[^1], HeadSimbol, HeadColor);
        }
        public void DrawFull(int delay = 0)
        {
            for (int i = 0; i < SnakeCoords.Length - 1; i++)
            {
                ConsoleDraw.Print(SnakeCoords[i], BodySimbol, BodyColor);
                ConsoleDraw.Print(SnakeCoords[i + 1], HeadSimbol, HeadColor);
                Thread.Sleep(delay);
            }
        }

        public void DrawHead()
        {
            ConsoleDraw.Print(SnakeCoords[^1], HeadSimbol, HeadColor);
        }

        public void ClearFull()
        {
            for (int i = 0; i < SnakeCoords.Length - 1; i++)
            {
                ConsoleDraw.Clear(SnakeCoords[i]);
            }
        }

        public void ClearFull(int delay)
        {
            ConsoleDraw.Clear(SnakeCoords[^1]);
            for (int i = 0; i < SnakeCoords.Length - 1; i++)
            {
                ConsoleDraw.Clear(SnakeCoords[i]);
                Thread.Sleep(delay);
            }
        }
    }
}
