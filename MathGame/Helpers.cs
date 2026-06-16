using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Helpers
    {
        static List<Game> games = new List<Game> { };

        internal static void ShowGameHistory()
        {
            Console.Clear();
            Console.WriteLine("Game History");
            Console.WriteLine("-------------------------------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type},{game.Difficulty}: {game.Score}pts in {game.Timer} seconds");
            }
            Console.WriteLine("\n-----------------------------------------------------\n");
            Console.WriteLine("Press any key to return to the Menu.");
            Console.ReadKey(true);
        }
        internal static void AddToHistory(int gameScore, GameType gameType, int time, Difficulty difficulty)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Timer = time,
                Difficulty = difficulty
            });
        }
        internal static int AnswerValidation()
        {
            int input;
            while (true)
            {
                Console.Write("Answer: ");
                string readLine = Console.ReadLine();
                if (!int.TryParse(readLine, out input))
                {
                    Console.WriteLine("Only numbers, please!");
                }
                else
                {
                    break;
                }
            }
            return input;
        }
        internal static char GetRandomOperator()
        {
            Random random = new Random();
            int x = random.Next(1, 5);
            Console.Write(x);
            switch (x)
            {
                case 1:
                    return '+';
                case 2:
                    return '-';
                case 3:
                    return '*';
                case 4:
                    return '/';
                default:
                    return '+';
            }
        }
        internal static (int answer, GameType gameType) CalculateAnswer(char mathOperator, int a, int b)
        {
            int answer = -1;
            GameType gameType = GameType.TEMP;
            switch (mathOperator)
            {
                case '+':
                    gameType = GameType.Addition;
                    answer = a + b;
                    break;

                case '-':
                    gameType = GameType.Subtraction;
                    answer = a - b;
                    break;

                case '*':
                    gameType = GameType.Multiplication;
                    answer = a * b;
                    break;

                case '/':
                    if (b == 0)
                    {
                        break;
                    }
                    if (a % b == 0)
                    {
                        gameType = GameType.Division;
                        answer = a / b;
                    }
                    break;

                default:
                    break;
            }
            return (answer, gameType);
        }

        internal static char ChooseMathOperator()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\nWhat would you like to do? Choose from the options below!");
                Console.WriteLine("1.[+]     2.[-]      3.[*]        4.[/]       5.[Random]      6.[Game History]       0.[Exit]");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                switch (keyInfo.KeyChar)
                {
                    case '1':
                        return '+';
                    case '2':
                        return '-';
                    case '3':
                        return '*';
                    case '4':
                        return '/';
                    case '5':
                        return 'x';
                    case '6':
                        Helpers.ShowGameHistory();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nPlease choose a valid option.\n");
                        break;
                }
            }
        }

        internal static int ChooseDifficulty()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\nSelect your difficulty!");
                Console.WriteLine("1.Easy      2.Normal        3.Hard   4.Go Back    0.[Exit]");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        return 1;
                    case '2':
                        return 2;
                    case '3':
                        return 3;
                    case '4':
                        return 4;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please choose an option.");
                        break;
                }
            }
        }

        internal static Difficulty GetDifficultyEnum(int difficultyChoice)
        {
            switch (difficultyChoice)
            {
                case 1:
                    return Difficulty.Easy;
                case 2:
                    return Difficulty.Normal;
                case 3:
                    return Difficulty.Hard;
                default:
                    return Difficulty.Temp;

            }
        }
    }
}
