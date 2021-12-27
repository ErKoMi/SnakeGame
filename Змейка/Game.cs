using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Threading;

namespace SnakeGame
{

    public class Game
    {
        //Параметры окна
        const int WIDTH = 135;
        const int HEIGHT = 50;
        //Параметры игрового поля
        const int FIELD_OFF_X = 1;
        const int FIELD_OFF_Y = 2;

        //меню
        Menu MainMenu = new Menu();
        //Поле
        Field GameField;
        //Змейка
        Snake Snake;
        //Счетчик
        ScoreBoard ScoreBoard;
        //Рекорд
        HighScoreBoard HighScoreBoard;

        //Еда
        ConsoleColor FoodColor { get; set; }
        string FoodSimbol { get; set; }
        Tuple<int, int> Foodplace;

        //Управление змейкой
        int GameDelay;
        ConsoleKey Dir;
        ConsoleKey LastDir;

        bool GameMode;



        public void StartGame()
        {

            if (MainMenu.Navigation() == true)
            {
                GameField = new(MainMenu.Sizes[(int)MainMenu.FieldSize], FIELD_OFF_X, FIELD_OFF_Y, MainMenu.BordColor, 
                    MainMenu.BordHorisontalUp, MainMenu.BordVerticalLeft, MainMenu.BordHorisontalDown, MainMenu.BordVerticalRight);
                Snake = new(new Tuple<int, int>[1] { GameField.GetCenter() },
                    MainMenu.snake_simbols[(int)MainMenu.BodySimbol], MainMenu.snake_simbols[(int)MainMenu.HeadSimbol], MainMenu.BodyColor, MainMenu.HeadColor);
                ScoreBoard = new ScoreBoard(MainMenu.BoardSimbol, Menu.BOARD_OFF_X, Menu.BOARD_OFF_Y, MainMenu.BoardColor);
                HighScoreBoard = MainMenu.highScoreBoard;
                GameMode = (MainMenu.GameMode == Menu.Mods.Wals);
                GameField.FieldDraw();
                Snake.DrawFull();
                ScoreBoard.ZeroBoard();
                HighScoreBoard.Draw();
                FoodSimbol = MainMenu.FoodSimbol;
                FoodColor = MainMenu.FoodColor;
                GameDelay = MainMenu.difficults[(int)MainMenu.Difficult];
                SpawnFood();
                Dir = ConsoleKey.UpArrow;
                ConsoleDraw.CPrint("Для управления змейкой используйте клавиши \"WSAD\" или клавиши со стрелками. Для паузы или выхода нажмите \"P\"(\"З\").", WIDTH / 2, HEIGHT - 4, ConsoleColor.DarkYellow);
                Controller();
                Console.BackgroundColor = ConsoleColor.Black;

            }
            else
                return;
        }
        void SpawnFood()
        {
            bool f;
            int x = 0, y = 0;
            do
            {
                f = true;
                Random rnd = new Random();

                x = rnd.Next(FIELD_OFF_X + 1, GameField.FieldWidth + FIELD_OFF_X);
                y = rnd.Next(FIELD_OFF_Y + 1, GameField.FieldHeight + FIELD_OFF_Y);
                foreach (Tuple<int, int> point in Snake.Coords)
                {
                    if (point.Item1 == x && point.Item2 == y)
                    {
                        f = false;
                    }
                }
            } while (!f);
            Foodplace = new Tuple<int, int>(x, y);

            ConsoleDraw.Print(FoodSimbol, Foodplace.Item1, Foodplace.Item2, FoodColor);
        }

        void SnakeManager()
        {
            if(Dir == ConsoleKey.UpArrow && LastDir == ConsoleKey.DownArrow ||
               Dir == ConsoleKey.LeftArrow && LastDir == ConsoleKey.RightArrow ||
               Dir == ConsoleKey.DownArrow && LastDir == ConsoleKey.UpArrow ||
               Dir == ConsoleKey.RightArrow && LastDir == ConsoleKey.LeftArrow)
            {
                Dir = LastDir;
            }
            else
            {
                LastDir = Dir;
            }

            int new_head_x = Snake.Coords[^1].Item1;
            int new_head_y = Snake.Coords[^1].Item2;

            switch (Dir)
            {
                case ConsoleKey.UpArrow:
                    new_head_y--;
                    break;
                case ConsoleKey.DownArrow:
                    new_head_y++;
                    break;
                case ConsoleKey.LeftArrow:
                    new_head_x--;
                    break;
                case ConsoleKey.RightArrow:
                    new_head_x++;
                    break;
            }
            if (new_head_x == FIELD_OFF_X || new_head_x == FIELD_OFF_X + GameField.FieldWidth || new_head_y == FIELD_OFF_Y || new_head_y == FIELD_OFF_Y + GameField.FieldHeight)
            {
                if (GameMode)
                    GameOver();
                else
                {
                    if (new_head_x == FIELD_OFF_X)
                        new_head_x += GameField.FieldWidth - 1;
                    if (new_head_x == FIELD_OFF_X + GameField.FieldWidth)
                        new_head_x = FIELD_OFF_X + 1;
                    if (new_head_y == FIELD_OFF_Y)
                        new_head_y += GameField.FieldHeight - 1;
                    if (new_head_y == FIELD_OFF_Y + GameField.FieldHeight)
                        new_head_y = FIELD_OFF_Y + 1;
                }
            }
            if (!Snake.Move(new Tuple<int, int>(new_head_x, new_head_y)))
            {
                GameOver();
            }
            if (new_head_x == Foodplace.Item1 && new_head_y == Foodplace.Item2)
            {
                Snake.Append(Foodplace);
                SpawnFood();
                ScoreBoard.UpdateBoard();
            }

        }

        void GameOver()

        {
            UpdateHightScore();
            Overlay overlay = new(new(40, 16), WIDTH / 2 - 15, HEIGHT / 2 - 3, GameField.BordColor, "@", "@", MainMenu.TitleColor, ConsoleColor.Black, MainMenu.FocusedParamColor);
            switch (overlay.Navigation())
            {
                case Overlay.Comands.Restart:
                    Console.BackgroundColor = MainMenu.BackGroundColor;
                    overlay.ClearField();
                    GameField.FieldDraw();
                    GameField.ClearField();
                    Snake = new(new Tuple<int, int>[1] { GameField.GetCenter() },
                MainMenu.snake_simbols[(int)MainMenu.BodySimbol], MainMenu.snake_simbols[(int)MainMenu.HeadSimbol], MainMenu.BodyColor, MainMenu.HeadColor);
                    ScoreBoard = new ScoreBoard(MainMenu.BoardSimbol, Menu.BOARD_OFF_X, Menu.BOARD_OFF_Y, MainMenu.BoardColor);
                    HighScoreBoard = MainMenu.highScoreBoard;
                    Snake.DrawFull();
                    ScoreBoard.ZeroBoard();
                    HighScoreBoard.Draw();
                    SpawnFood();
                    Controller();
                    break;
                case Overlay.Comands.Menu:
                    Clear();
                    MainMenu.DrawMenu();
                    StartGame();
                    break;
                case Overlay.Comands.Exit:
                    Clear();
                    Environment.Exit(0);
                    break;
            }
        }

        void Clear()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                ConsoleDraw.Clear(new string(' ', WIDTH), 0, i);
                Thread.Sleep(5);
            }
        }

        void UpdateHightScore()
        {
            if(ScoreBoard.Score > HighScoreBoard.Score)
            {
                HighScoreBoard.UpdateBoard(ScoreBoard.Score);
            }
        }

        void Controller()
        {
            ConsoleKey key;
            key = Console.ReadKey(true).Key;
            while (key != ConsoleKey.Enter)
            {
                Thread.Sleep(250);
                key = Console.ReadKey(true).Key;
            }
            do
            {
                while (!Console.KeyAvailable)
                {
                    SnakeManager();
                    Thread.Sleep(GameDelay);
                }
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    Dir = ConsoleKey.UpArrow;
                }
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    Dir = ConsoleKey.DownArrow;
                }
                if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
                {
                    Dir = ConsoleKey.LeftArrow;
                }
                if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
                {
                    Dir = ConsoleKey.RightArrow;
                }
                if (key == ConsoleKey.P || key == ConsoleKey.Escape)
                {
                    Overlay overlay = new(new(40, 16), WIDTH / 2 - 20, HEIGHT / 2 - 8, GameField.BordColor, "@", "@",
                        ConsoleColor.DarkYellow, ConsoleColor.Black, MainMenu.FocusedParamColor, true);
                    switch (overlay.Navigation())
                    {
                        case Overlay.Comands.Restart:
                            Console.BackgroundColor = MainMenu.BackGroundColor;
                            UpdateHightScore();
                            overlay.ClearField();
                            GameField.FieldDraw();
                            GameField.ClearField();
                            Snake = new(new Tuple<int, int>[1] { GameField.GetCenter() },
                        MainMenu.snake_simbols[(int)MainMenu.BodySimbol], MainMenu.snake_simbols[(int)MainMenu.HeadSimbol], MainMenu.BodyColor, MainMenu.HeadColor);
                            ScoreBoard = new ScoreBoard(MainMenu.BoardSimbol, Menu.BOARD_OFF_X, Menu.BOARD_OFF_Y, MainMenu.BoardColor);
                            HighScoreBoard = MainMenu.highScoreBoard;
                            Snake.DrawFull();
                            ScoreBoard.ZeroBoard();
                            HighScoreBoard.Draw();
                            SpawnFood();
                            Controller();
                            break;
                        case Overlay.Comands.Menu:
                            Clear();
                            UpdateHightScore();
                            MainMenu.DrawMenu();
                            StartGame();
                            break;
                        case Overlay.Comands.Exit:
                            Clear();
                            UpdateHightScore();
                            Environment.Exit(0);
                            break;
                        case Overlay.Comands.Return:
                            Console.BackgroundColor = MainMenu.BackGroundColor;
                            overlay.ClearField();
                            GameField.FieldDraw();
                            Snake.DrawFull();
                            ConsoleDraw.Print(Foodplace, FoodSimbol, FoodColor);
                            break;
                    }
                }

            } while (true);
        }
    }
}
