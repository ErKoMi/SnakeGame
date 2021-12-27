using System;
using System.Threading;

namespace SnakeGame
{
    public class Overlay : Field
    {
        const int TITLE_OFF_X = 10;
        const int TITLE_OFF_Y = 2;
        const string TITLE_SIMBOL = "#";
        ConsoleColor TitleColor;
        ConsoleColor ButtonColor;
        ConsoleColor FocusedButtomColor;
        bool pause;
        const ConsoleColor DeathColor = ConsoleColor.Red;

        public Overlay(Tuple<int, int> s, int offsetX, int offsetY, ConsoleColor bordColor, string bordHorisontal, string bordVertical, ConsoleColor titleColor, ConsoleColor buttonColor, ConsoleColor focusedButtomColor, bool pause = false) : base(s, offsetX, offsetY, bordColor, bordHorisontal, bordVertical)
        {
            TitleColor = titleColor;
            ButtonColor = buttonColor;
            FocusedButtomColor = focusedButtomColor;
            this.pause = pause;
        }

        public enum Comands
        {
            Restart, Menu, Exit, Return
        }
        private readonly Tuple<int, int>[] comands =
        {
            new(10, 9), new(30,9), new(20, 12)
        };
        private readonly string[] RusComands =
        {
            "Рестарт", "Главное меню", "Выйти из игры",
        };


        public override void ClearField()
        {
            for (int i = FieldHeight; i >=0 ; i--)
            {
                for (int j = FieldWidth; j >= 0; j--)
                {
                    ConsoleDraw.Clear(new Tuple<int, int>(j, i), OffsetX, OffsetY);
                }
                Thread.Sleep(5);
            }
        }

        public override void FieldDraw()
        {
            Console.BackgroundColor = ConsoleColor.White;
            ConsoleDraw.Print(new String(BordHorisontalUp[0], FieldWidth), OffsetX, OffsetY, BordColor);
            for(int i = 1; i <= FieldHeight-1; i++)
            {
                ConsoleDraw.Print("@" + new String(' ', FieldWidth-2) + "@", OffsetX, OffsetY + i, BordColor);
                Thread.Sleep(5);
            }
            ConsoleDraw.Print(new String(BordHorisontalUp[0], FieldWidth), OffsetX, OffsetY + FieldHeight, BordColor);
            MenuDraw();
        }

        void MenuDraw()
        {
            if (pause)
            {
                ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.П, OffsetX + TITLE_OFF_X, OffsetY + TITLE_OFF_Y, TITLE_SIMBOL, TitleColor);
                ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.А, OffsetX + TITLE_OFF_X + 4, OffsetY + TITLE_OFF_Y, TITLE_SIMBOL, TitleColor);
                ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.У, OffsetX + TITLE_OFF_X + 10, OffsetY + TITLE_OFF_Y, TITLE_SIMBOL, TitleColor);
                ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.З, OffsetX + TITLE_OFF_X + 14, OffsetY + TITLE_OFF_Y, TITLE_SIMBOL, TitleColor);
                ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.А, OffsetX + TITLE_OFF_X + 18, OffsetY + TITLE_OFF_Y, TITLE_SIMBOL, TitleColor);
                ConsoleDraw.CPrint("Для выхода из паузы нажмите \"P\"(\"З\")", OffsetX + 20, OffsetY + 14, TitleColor);
            }
            else
            {
                ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.К, OffsetX + TITLE_OFF_X, OffsetY + TITLE_OFF_Y, TITLE_SIMBOL, DeathColor);
                ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.О, OffsetX + TITLE_OFF_X + 5, OffsetY + TITLE_OFF_Y, TITLE_SIMBOL, DeathColor);
                ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Н, OffsetX + TITLE_OFF_X + 9, OffsetY + TITLE_OFF_Y, TITLE_SIMBOL, DeathColor);
                ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Е, OffsetX + TITLE_OFF_X + 13, OffsetY + TITLE_OFF_Y, TITLE_SIMBOL, DeathColor);
                ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Ц, OffsetX + TITLE_OFF_X + 17, OffsetY + TITLE_OFF_Y, TITLE_SIMBOL, DeathColor);
                ConsoleDraw.CPrint("Вы проиграли!", OffsetX + 20, OffsetY + 14, DeathColor);
            }

            for (int comand = 0; comand < comands.Length; comand++)
            {
                ConsoleDraw.CPrint(RusComands[comand].ToLower(), comands[(int)comand].Item1 + OffsetX, comands[(int)comand].Item2 + OffsetY, ButtonColor);
            }
        }

        void ComandFocus(Comands comand)
        {
            int not_focus = (comands.Length - 1 + (int)comand) % comands.Length;
            ConsoleDraw.CPrint(RusComands[(int)not_focus].ToLower(), comands[(int)not_focus].Item1 + OffsetX, comands[(int)not_focus].Item2 + OffsetY, ButtonColor);
            ConsoleDraw.CPrint(RusComands[(int)comand].ToUpper(), comands[(int)comand].Item1 + OffsetX, comands[(int)comand].Item2 + OffsetY, FocusedButtomColor);
        }

        public Comands Navigation()
        {
            FieldDraw();
            int focus = 0;
            ComandFocus((Comands)focus);
            while (!Console.KeyAvailable)
                Thread.Sleep(200);
            ConsoleKey key = ConsoleKey.C;
            do
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Tab)
                {
                    focus++;
                    if (focus == comands.Length)
                        focus = 0;
                    ComandFocus((Comands)focus);
                }
                if (key == ConsoleKey.P && pause)
                {
                    return Comands.Return;
                }
            } while (key != ConsoleKey.Enter);
            return (Comands)focus;

        }
    }
}
