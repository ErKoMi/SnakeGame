using System;
using System.Collections.Specialized;
using System.Configuration;

namespace SnakeGame
{
    public class HighScoreBoard : ScoreBoard
    {
        
        public HighScoreBoard(string simbol, int offX, int offY, ConsoleColor color, int score) : base(simbol, offX, offY, color)
        {
            Score = score;
            GetDigits();
        }
        ConsoleDraw.Numbers[] ScoreDigits = new ConsoleDraw.Numbers[SCORE_DIGITS];

        void GetDigits()
        {
            int num = Score;
            for (int i = SCORE_DIGITS - 1; i >= 0; i--)
            {
                ScoreDigits[i] = (ConsoleDraw.Numbers)(num % 10);
                num /= 10;
            }
        }

        public void Draw()
        {
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Р, OffX, OffY, Simbol, Color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Е, OffX + 4, OffY, Simbol, Color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.К, OffX + 8, OffY, Simbol, Color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.О, OffX + 13, OffY, Simbol, Color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Р, OffX + 17, OffY, Simbol, Color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Д, OffX + 21, OffY, Simbol, Color);
            DrawScore();
        }

        public void DrawScore()
        {
            GetDigits();
            ConsoleDraw.PrintNumber(ScoreDigits, OffX + 5, OffY + OFFSET, Simbol, Color);
        }

        public void ResetScore()
        {
            Score = 0;
            GetDigits();
            DrawScore();
        }
        public void UpdateBoard( int NewScore)
        {
            GetDigits();
            ConsoleDraw.PrintNumber(ScoreDigits, OffX + 5, OffY + OFFSET, " ", Color);
            Score = NewScore;
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Record"].Value = NewScore.ToString();
            config.Save();
            DrawScore();
        }

    }
}
