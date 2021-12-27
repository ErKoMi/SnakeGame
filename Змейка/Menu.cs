using System;
using System.Threading;
using System.Configuration;
using System.Collections.Specialized;

namespace SnakeGame
{
    public class Menu
    {
        //Параметры окна
        const int WIDTH = 135;
        const int HEIGHT = 50;
        //Параметры меню
        const int TITLE_OFF_X = WIDTH / 2 - 20;
        const int TITLE_OFF_Y = 3;
        const int START_OFF_X = WIDTH / 2 - 9;
        const int START_OFF_Y = 34;
        const string TITLE_SIMBOL = "@";
        const int MENU_OFFSET_Y = 23;
        const int ITEMS_OFFSET = 2; //Отступ параметра от элемента меню
        int CountParams { get; set; }
        public ConsoleColor TitleColor { get; set; }
        ConsoleColor StartColor { get; set; }
        public ConsoleColor FocusedParamColor { get; set; }
        ConsoleColor FocusedStartColor { get; set; }
        const int CLEAR_DELAY = 5;
        Snake snake;
        const int TEST_SNAKE_ITER = 7;
        const int TEST_SNAKE_OFFSET = 10;
        const int TEST_SNAKE_RENDER_DELAY = 6;
        Field field;
        Tuple<int, int> TEST_FIELD_SIZES = new(45, 17);
        const int TIPS_OFF_X = WIDTH / 2;
        const int TIPS_OFF_Y = HEIGHT - 5;

        
        public FieldSizes FieldSize { get; set; }
        public ConsoleColor BordColor { get; set; }
        public string BordHorisontalUp { get; set; }
        public string BordHorisontalDown { get; set; }
        public string BordVerticalLeft { get; set; }
        public string BordVerticalRight { get; set; }
        public ConsoleColor BackGroundColor { get; set; }
        //Параметры счетчика
        public const int BOARD_OFF_X = 108;
        public const int BOARD_OFF_Y = 5;
        public const int HIGH_BOARD_OFF_X = 103;
        public const int HIGH_BOARD_OFF_Y = 25;
        public ConsoleColor BoardColor { get; set; }
        public string BoardSimbol { get; set; }
        public HighScoreBoard highScoreBoard;
        int HighScore { get; set; }
        //Параметры змейки
        public Simbols BodySimbol { get; set; }
        public Simbols HeadSimbol { get; set; }
        public ConsoleColor BodyColor { get; set; }
        public ConsoleColor HeadColor { get; set; }
        public ConsoleColor FoodColor { get; set; }
        public string FoodSimbol { get; set; }
        //Параметры игры
        public Mods GameMode { get; set; }
        public Difficults Difficult { get; set; }
        Themes Theme { get; set; }


        //Элементы меню
        Tuple<int, int>[] GameParams =
        {
            new Tuple<int, int>(START_OFF_X, START_OFF_Y),
            new Tuple<int, int>(48, MENU_OFFSET_Y),
            new Tuple<int, int>(68, MENU_OFFSET_Y),
            new Tuple<int, int>(86, MENU_OFFSET_Y),
            new Tuple<int, int>(48, MENU_OFFSET_Y+6),
            new Tuple<int, int>(68, MENU_OFFSET_Y+6),
            new Tuple<int, int>(86, MENU_OFFSET_Y+6),
            new Tuple<int, int>(47, MENU_OFFSET_Y+18),
            new Tuple<int, int>(71, MENU_OFFSET_Y+18),
            new Tuple<int, int>(92, MENU_OFFSET_Y+18),

        };
        //перечисление элементов меню
        enum Params
        {
            START, Difficult, FieldSize, Mode, Head, Body, Theme, Default, DoDefault, ResetHighScore
        }

        readonly string[] RusParams = new string[]
        {
            "Старт", "Сложность", "Размер поля", "Игровой режим", "Голова", "Хвост", "Тема",  "Настройки по умолчанию", "Сделать по умолчанию", "Сбросить рекорд"
        };
        readonly string[] Tips =
        {
            "Для начала игры нажмите \"Enter\"", "выбор скорости перемещения змейки", "столбцы х строчки", "плоская земля - стенки убивают, круглая земля - змейка появляется с противоложной стороны при выходе за границу поля", 
            "символ, обозначающий голову", "символ, обозначающий хвост", "тема влияет на цветовую гамму и символы некоторых элементов",
            "Восстановить настройки по умолчанию", "Сделать текущие настройки настройками по умолчанию", "Сброс рекорда. Для подтверждения нажмите \"Enter\" еще раз."
        };


        //Уровни сложности
        public enum Difficults
        {
            Normal,
            Fast,
            VeryFast,
            DraconBorn,
            VerySlow,
            Slow,
        }

        public readonly int[] difficults = new int[]
        {
            80, 50, 30, 10, 150, 200
        };
        string[] RusDifficults = new string[]
        { 
            "нормально", "быстро", "очень быстро", "довакин", "очень медленно", "медленно"
        };


        /// <summary>
        /// перечисление размеров поля
        /// </summary>
        public enum FieldSizes
        {
             Mid, Big, Small_Square, Square,  Small
        }

        public readonly Tuple<int, int>[] Sizes = { new Tuple<int, int> (80, 40), new Tuple<int, int> (100, 40), new Tuple<int, int> (20, 20),
            new Tuple<int, int> (40, 40),  new Tuple<int, int> (60, 40)};
        //Темы
        enum Themes
        {
            ChinaDragon, SeaDragon, NewYear
        }

        readonly string[] RusThemes = new string[]
        {
            "китайский дракон", "морской дракон", "новогодняя"
        };
        //Режимы
        public enum Mods
        {
            Wals,
            NoWals
        }

        readonly string[] RusMods = new string[]
        {
            "плоская земля", "круглая земля"
        };

        //Символы для змейки
        public enum Simbols
        {
            Dog, Heart, X, Sharp, Percent, Dollar
        }

        public readonly string[] snake_simbols = new string[]
        {
            "@", "♥", "X", "#", "%", "$"
        };


        void SetTheme(Themes theme)
        {
            switch (theme)
            {
                case Themes.ChinaDragon:
                    TitleColor = ConsoleColor.Green;
                    StartColor = ConsoleColor.Red;
                    BordColor = ConsoleColor.DarkRed;
                    BordHorisontalDown = "▄";
                    BordHorisontalUp = "▀";
                    BordVerticalLeft = "▐";
                    BordVerticalRight = "▌";
                    BoardSimbol = "#";
                    BoardColor = ConsoleColor.DarkYellow;
                    BodyColor = ConsoleColor.Yellow;
                    HeadColor = ConsoleColor.Red;
                    FocusedParamColor = ConsoleColor.DarkYellow;
                    FocusedStartColor = ConsoleColor.DarkRed;
                    BackGroundColor = ConsoleColor.Black;
                    FoodSimbol = "+";
                    FoodColor = ConsoleColor.Green;
                    break;
                case Themes.SeaDragon:
                    TitleColor = ConsoleColor.DarkBlue;
                    StartColor = ConsoleColor.Blue;
                    FocusedParamColor = ConsoleColor.Cyan;
                    FocusedStartColor = ConsoleColor.DarkBlue;
                    BodyColor = ConsoleColor.Black;
                    HeadColor = ConsoleColor.Blue;
                    BordHorisontalDown = "X";
                    BordHorisontalUp = "X";
                    BordVerticalLeft = "X";
                    BordVerticalRight = "X";
                    BordColor = ConsoleColor.Magenta;
                    BoardSimbol = "@";
                    BoardColor = ConsoleColor.DarkYellow;
                    BackGroundColor = ConsoleColor.Cyan;
                    FoodSimbol = "&";
                    FoodColor = ConsoleColor.DarkBlue;
                    break;
                case Themes.NewYear:
                    TitleColor = ConsoleColor.DarkBlue;
                    StartColor = ConsoleColor.Cyan;
                    FocusedParamColor = ConsoleColor.Blue;
                    FocusedStartColor = ConsoleColor.DarkCyan;
                    BodyColor = ConsoleColor.Green;
                    HeadColor = ConsoleColor.Red;
                    BordHorisontalDown = "O";
                    BordHorisontalUp = "O";
                    BordVerticalLeft = "O";
                    BordVerticalRight = "O";
                    BordColor = ConsoleColor.DarkBlue;
                    BoardSimbol = "*";
                    BoardColor = ConsoleColor.Magenta;
                    BackGroundColor = ConsoleColor.White;
                    FoodSimbol = "*";
                    FoodColor = ConsoleColor.DarkCyan;
                    break;
            }
        }
        void GetDefaultProperties()
        {
            Difficult = (Difficults)int.Parse(ConfigurationManager.AppSettings.Get("Difficult"));
            FieldSize = (FieldSizes)int.Parse(ConfigurationManager.AppSettings.Get("Size"));
            GameMode = (Mods)int.Parse(ConfigurationManager.AppSettings.Get("Mode"));
            HeadSimbol = (Simbols)int.Parse(ConfigurationManager.AppSettings.Get("Head"));
            BodySimbol = (Simbols)int.Parse(ConfigurationManager.AppSettings.Get("Body"));
            Theme = (Themes)int.Parse(ConfigurationManager.AppSettings.Get("Theme"));
            HighScore = int.Parse(ConfigurationManager.AppSettings.Get("Record"));
            SetTheme(Theme);
        }
        void SetDefaultProperties()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Difficult"].Value = ((int)Difficult).ToString();
            config.AppSettings.Settings["Size"].Value = ((int)FieldSize).ToString();
            config.AppSettings.Settings["Mode"].Value = ((int)GameMode).ToString();
            config.AppSettings.Settings["Head"].Value = ((int)HeadSimbol).ToString();
            config.AppSettings.Settings["Body"].Value = ((int)BodySimbol).ToString();
            config.AppSettings.Settings["Theme"].Value = ((int)Theme).ToString();
            config.Save();
        }
        void ResetHighScore()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Record"].Value = "0";
            config.Save();
            highScoreBoard.ResetScore();
        }

        //Координаты тестовой змейки
        static Tuple<int,int>[] TestSnake(int count)
        {
            Tuple<int, int>[] snake_elem = new Tuple<int, int>[]
            {
                new Tuple<int, int>(0 + TITLE_OFF_X, 2 + TITLE_OFF_Y + TEST_SNAKE_OFFSET),
                new Tuple<int, int>(1 + TITLE_OFF_X, 2 + TITLE_OFF_Y + TEST_SNAKE_OFFSET),
                new Tuple<int, int>(1 + TITLE_OFF_X, 1 + TITLE_OFF_Y + TEST_SNAKE_OFFSET),
                new Tuple<int, int>(1 + TITLE_OFF_X, 0 + TITLE_OFF_Y + TEST_SNAKE_OFFSET),
                new Tuple<int, int>(2 + TITLE_OFF_X, 0 + TITLE_OFF_Y + TEST_SNAKE_OFFSET),
                new Tuple<int, int>(3 + TITLE_OFF_X, 0 + TITLE_OFF_Y + TEST_SNAKE_OFFSET),
                new Tuple<int, int>(4 + TITLE_OFF_X, 0 + TITLE_OFF_Y + TEST_SNAKE_OFFSET),
                new Tuple<int, int>(4 + TITLE_OFF_X, 1 + TITLE_OFF_Y + TEST_SNAKE_OFFSET),
                new Tuple<int, int>(4 + TITLE_OFF_X, 2 + TITLE_OFF_Y + TEST_SNAKE_OFFSET),
                new Tuple<int, int>(5 + TITLE_OFF_X, 2 + TITLE_OFF_Y + TEST_SNAKE_OFFSET)
            };
            Tuple<int, int>[] snake = new Tuple<int, int>[snake_elem.Length*count];
            for(int i = 0; i < count; i++)
            {
                for (int j = 0; j < snake_elem.Length; j++)
                {
                    snake[i * snake_elem.Length + j] = new Tuple<int, int>(snake_elem[j].Item1 + (snake_elem.Length-4)*i, snake_elem[j].Item2);
                }
            }
            return snake;
        }
        public void DrawTitle()
        {
            Console.BackgroundColor = BackGroundColor;  
            field = new(TEST_FIELD_SIZES, TITLE_OFF_X - 2, TITLE_OFF_Y - 2, BordColor, BordHorisontalUp, BordVerticalLeft, BordHorisontalDown, BordVerticalRight);
            field.FieldDraw();
            field.ClearField();
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Зbig, 0 + TITLE_OFF_X, TITLE_OFF_Y, TITLE_SIMBOL, TitleColor);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Mbig, 6 + TITLE_OFF_X, TITLE_OFF_Y, TITLE_SIMBOL, TitleColor);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Еbig, 14 + TITLE_OFF_X, TITLE_OFF_Y, TITLE_SIMBOL, TitleColor);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Йbig, 20 + TITLE_OFF_X, TITLE_OFF_Y, TITLE_SIMBOL, TitleColor);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Кbig, 27 + TITLE_OFF_X, TITLE_OFF_Y, TITLE_SIMBOL, TitleColor);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Аbig, 34 + TITLE_OFF_X, TITLE_OFF_Y, TITLE_SIMBOL, TitleColor);
            snake = new(TestSnake(TEST_SNAKE_ITER), snake_simbols[(int)BodySimbol], snake_simbols[(int)HeadSimbol], BodyColor, HeadColor);
            snake.DrawFull(TEST_SNAKE_RENDER_DELAY);
            Console.BackgroundColor = ConsoleColor.Black;
            DrawStart(StartColor);
        }

        public void DrawMenu()
        {
            DrawTitle();
            DrawStart(StartColor);
            foreach (Params param in Enum.GetValues(typeof(Params)))
            {
                if(param == Params.START)
                {
                    continue;
                }
                ConsoleDraw.CPrint(RusParams[(int)param].ToLower(), GameParams[(int)param].Item1, GameParams[(int)param].Item2);
                string def = " ";
                switch (param)
                {
                    case Params.Difficult:
                        def = RusDifficults[(int)Difficult].ToLower();
                        break;
                    case Params.FieldSize:
                        def = String.Format("{0} x {1}", Sizes[(int)FieldSize].Item1, Sizes[(int)FieldSize].Item2);
                        break;
                    case Params.Mode:
                        def = RusMods[(int)GameMode].ToLower(); ;
                        break;
                    case Params.Head:
                        def = snake_simbols[(int)HeadSimbol];
                        break;
                    case Params.Body:
                        def = snake_simbols[(int)BodySimbol];
                        break;
                    case Params.Theme:
                        def = RusThemes[(int)Theme];
                        break;
                }
                ConsoleDraw.CPrint(def, GameParams[(int)param].Item1, GameParams[(int)param].Item2 + ITEMS_OFFSET);
            }
            highScoreBoard = new HighScoreBoard(BoardSimbol, HIGH_BOARD_OFF_X, HIGH_BOARD_OFF_Y, BoardColor, HighScore);
            highScoreBoard.Draw();
            ConsoleDraw.CPrint("Для навигации по меню используйте \"Tab\". Для изменения элемента - кнопки со стрелками или \"a\" \"d\".", TIPS_OFF_X, TIPS_OFF_Y + 3, ConsoleColor.DarkYellow);
        }

        void ClearMenu()
        {
            Console.BackgroundColor = BackGroundColor;
            snake.ClearFull(TEST_SNAKE_ITER);
            for (int i = 0; i < HEIGHT; i++)
            {
                ConsoleDraw.Clear(new string(' ', WIDTH), 0, i);
                Thread.Sleep(CLEAR_DELAY);
            }
        }

        void MenuFocus(Params param)
        {
            int not_focus =  (CountParams - 1 + (int)param) % CountParams;
            if ((Params)not_focus == Params.START)
            {
                DrawStart(StartColor);
            }
            else
            {
                ConsoleDraw.CPrint(RusParams[(int)not_focus].ToLower(), GameParams[(int)not_focus].Item1, GameParams[(int)not_focus].Item2); 
            }
            if (param == Params.START)
            {
                DrawStart(FocusedStartColor);
            }
            else
            {
                ConsoleDraw.CPrint(RusParams[(int)param].ToUpper(), GameParams[(int)param].Item1, GameParams[(int)param].Item2, FocusedParamColor); 
            }
            ConsoleDraw.Print(new String(' ', WIDTH), 0, TIPS_OFF_Y);
            ConsoleDraw.CPrint(Tips[(int)param].ToUpper(), TIPS_OFF_X, TIPS_OFF_Y);
        }

        void ItemFocus(Params param, int dir)
        {
            int count;
            int x = GameParams[(int)param].Item1;
            int y = GameParams[(int)param].Item2 + ITEMS_OFFSET;
            switch (param)
            {
                case Params.Difficult:
                    count = Enum.GetValues(typeof(Difficults)).Length;
                    count = (count + (int)Difficult + dir) % count;
                    ConsoleDraw.CClear(RusDifficults[(int)Difficult], x, y);
                    Difficult = (Difficults)count;
                    ConsoleDraw.CPrint(RusDifficults[(int)Difficult], x, y);
                    break;
                case Params.FieldSize:
                    count = Sizes.Length;
                    count = (count + (int)FieldSize + dir) % count;
                    string s = String.Format("{0} x {1}", Sizes[(int)FieldSize].Item1, Sizes[(int)FieldSize].Item2);
                    ConsoleDraw.CClear(s, x, y);
                    FieldSize = (FieldSizes)count;
                    s = String.Format("{0} x {1}", Sizes[(int)FieldSize].Item1, Sizes[(int)FieldSize].Item2);
                    ConsoleDraw.CPrint(s, x, y);
                    break;
                case Params.Mode:
                    count = Enum.GetValues(typeof(Mods)).Length;
                    count = (count + (int)GameMode + dir) % count;
                    ConsoleDraw.CClear(RusMods[(int)GameMode], x, y);
                    GameMode = (Mods)count;
                    ConsoleDraw.CPrint(RusMods[(int)GameMode], x, y);
                    break;
                case Params.Head:
                    count = snake_simbols.Length;
                    count = (count + (int)HeadSimbol+ dir) % count;
                    ConsoleDraw.CClear(snake_simbols[(int)HeadSimbol], x, y);
                    HeadSimbol = (Simbols)count;
                    ConsoleDraw.CPrint(snake_simbols[(int)HeadSimbol], x, y);
                    snake = new(TestSnake(TEST_SNAKE_ITER), snake_simbols[(int)BodySimbol], snake_simbols[(int)HeadSimbol], BodyColor, HeadColor);
                    Console.BackgroundColor = BackGroundColor;
                    snake.DrawHead();
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case Params.Body:
                    count = snake_simbols.Length;
                    count = (count + (int)BodySimbol + dir) % count;
                    ConsoleDraw.CClear(snake_simbols[(int)BodySimbol], x, y);
                    BodySimbol = (Simbols)count;
                    ConsoleDraw.CPrint(snake_simbols[(int)BodySimbol], x, y);
                    snake = new(TestSnake(TEST_SNAKE_ITER), snake_simbols[(int)BodySimbol], snake_simbols[(int)HeadSimbol], BodyColor, HeadColor);
                    Console.BackgroundColor = BackGroundColor;
                    snake.DrawFull();
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case Params.Theme:
                    count = Enum.GetValues(typeof(Themes)).Length;
                    count = (count + (int)Theme + dir) % count;
                    ConsoleDraw.CClear(RusThemes[(int)Theme], x, y);
                    Theme = (Themes)count;
                    ConsoleDraw.CPrint(RusThemes[(int)Theme], x, y);
                    SetTheme(Theme);
                    DrawTitle();
                    highScoreBoard = new HighScoreBoard(BoardSimbol, HIGH_BOARD_OFF_X, HIGH_BOARD_OFF_Y, BoardColor, HighScore);
                    highScoreBoard.Draw();
                    MenuFocus(param);
                    break;
            }
        }

        void DrawStart(ConsoleColor color)
        {
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.С, START_OFF_X, START_OFF_Y, TITLE_SIMBOL, color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Т, START_OFF_X + 4, START_OFF_Y, TITLE_SIMBOL, color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.А, START_OFF_X + 8, START_OFF_Y, TITLE_SIMBOL, color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Р, START_OFF_X + 14, START_OFF_Y, TITLE_SIMBOL, color);
            ConsoleDraw.PrintLetter(ConsoleDraw.Alphabet.Т, START_OFF_X + 18, START_OFF_Y, TITLE_SIMBOL, color);
        }
        public bool Navigation()
        {
            int focus = 0;
            bool change = false, reset_high_score = false;
            MenuFocus((Params)focus);
            do
            {
                while (!Console.KeyAvailable)
                    Thread.Sleep(200);
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Tab)
                {
                    focus++;
                    if (focus == CountParams)
                        focus = 0;
                    MenuFocus((Params)focus);
                    reset_high_score = false;
                }
                if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
                {
                    ItemFocus((Params)focus, 1);
                    change = true;
                }
                if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
                {
                    ItemFocus((Params)focus, -1);
                    change = true;
                }
                if (key == ConsoleKey.Escape)
                {
                    return false;
                }
                if (key == ConsoleKey.Enter)
                {
                    if((Params)focus == Params.Default && change)
                    {
                        GetDefaultProperties();
                        Console.Clear();
                        DrawTitle();
                        DrawMenu();
                        MenuFocus((Params)focus);
                        change = false;
                    }
                    if((Params)focus == Params.DoDefault && change)
                    {
                        SetDefaultProperties();
                        change = false;
                    }
                    if((Params)focus == Params.ResetHighScore && HighScore != 0)
                    {
                        if (!reset_high_score)
                            reset_high_score = true;
                        else
                            ResetHighScore();
                    }
                    if((Params)focus == Params.START)
                    {
                        ClearMenu();
                        return true;
                    }
                   
                }
            } while (true);
            return false;
        }

        public Menu()
        {
            Console.WindowWidth = WIDTH;
            Console.BufferWidth = Console.WindowWidth;
            Console.WindowHeight = HEIGHT;
            Console.BufferHeight = Console.WindowHeight;
            CountParams = Enum.GetValues(typeof(Params)).Length;
            GetDefaultProperties();
            DrawMenu();
        }
    }
}
