using System;

namespace SnakeGame
{
    public class ScoreBoard
    {
        public int Score { get; set; }
        protected const int SCORE_DIGITS = 4;
        private protected string Simbol { get; }
        private protected int OffX { get; }
        private protected int OffY { get; }
        private protected int OFFSET = 8; // отступ числа от надписи    
        private protected ConsoleColor Color { get; }

        public ScoreBoard(string simbol, int offX, int offY, ConsoleColor color)
        {
            Simbol = simbol;
            OffX = offX;
            OffY = offY;
            Color = color;
        }
        public void UpdateBoard()
        {
            Score++;
            int num = Score;
            int prev = Score - 1;
            int dig = 0;
            while (num != 0)
            {
                int offset = OffX + SCORE_DIGITS * (SCORE_DIGITS - 1 - dig);
                int n = num % 10;
                int p = prev % 10;
                if (!(n==p))
                {
                    ConsoleDraw.ClearDigit((ConsoleDraw.Numbers)p, offset, OffY + OFFSET);
                    ConsoleDraw.PrintDigit((ConsoleDraw.Numbers)n, offset, OffY + OFFSET, Simbol, Color);
                }
                num /= 10;
                prev /= 10;
                dig++;
            }
        }
        public void ZeroBoard()
        {
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.С, OffX, OffY, Simbol, Color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Ч, OffX+4, OffY, Simbol, Color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Е, OffX+8, OffY, Simbol, Color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Т, OffX+12, OffY, Simbol, Color);
            ConsoleDraw.PrintNumber(new ConsoleDraw.Numbers[] { ConsoleDraw.Numbers.ZERO, ConsoleDraw.Numbers.ZERO, ConsoleDraw.Numbers.ZERO, ConsoleDraw.Numbers.ZERO },
                OffX, OffY + OFFSET, Simbol, Color);
        }
    }
}
