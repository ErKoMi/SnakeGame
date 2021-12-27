using System;
using System.Threading;

namespace SnakeGame
{
    public class Field
    {
        public int FieldHeight { get;}
        public int FieldWidth { get;}
        private protected int OffsetX { get; }
        private protected int OffsetY { get; }
        public ConsoleColor BordColor { get; }
        private protected string BordHorisontalUp { get; }
        private string BordHorisontalDown { get; }
        private string BordVerticalLeft { get; }
        private string BordVerticalRight { get; }



        public Field(Tuple<int,int> s, int offsetX, int offsetY, ConsoleColor bordColor, string bordHorisontal, string bordVertical,
            string bordHorisontalDown = null, string bordVerticalRight = null)
        {
            FieldHeight = s.Item2;
            FieldWidth = s.Item1;
            OffsetX = offsetX;
            OffsetY = offsetY;
            BordColor = bordColor;
            BordHorisontalUp = bordHorisontal;
            BordVerticalLeft = bordVertical;
            if (bordHorisontalDown == null)
                BordHorisontalDown = bordHorisontal;
            else
                BordHorisontalDown = bordHorisontalDown;
            if (bordVerticalRight == null)
                BordVerticalRight = bordVertical;
            else
                BordVerticalRight = bordVerticalRight;
        }

        public Tuple<int,int> GetCenter()
        {
            return new Tuple<int, int>(FieldWidth / 2 + OffsetX, FieldHeight / 2 + OffsetY);
        }


        public virtual void FieldDraw()
        {
            for (int i = 0; i < FieldWidth + 1; i++)
            {
                ConsoleDraw.Print(new Tuple<int, int>(i, FieldHeight), BordHorisontalUp, BordColor, OffsetX, OffsetY);
                ConsoleDraw.Print(new Tuple<int, int>(i, 0), BordHorisontalDown, BordColor, OffsetX, OffsetY);
            }
            for (int i = 1; i < FieldHeight; i++)
            {
                ConsoleDraw.Print(new Tuple<int, int>(FieldWidth, i), BordVerticalLeft, BordColor, OffsetX, OffsetY);
                ConsoleDraw.Print(new Tuple<int, int>(0, i), BordVerticalRight, BordColor, OffsetX, OffsetY);
            }
        }

        public virtual void ClearField()
        {
            for(int i = 1; i <= FieldHeight - 1; i++)
            {
                for (int j = 1; j <= FieldWidth - 1; j++)
                {
                    ConsoleDraw.Clear(new Tuple<int, int>(j, i), OffsetX, OffsetY);
                }
            }
        }
    }
}
