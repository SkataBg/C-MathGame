using System.Diagnostics.Metrics;
using System.Timers;
namespace MathGame
{
    internal class GameEngine
    {
        int score;
        int counter;
        internal void StartGame(char operatorChoice, int difficultyChoice)
        {
            score = 0;
            counter = 0;
            Random random = new Random();
            GameType gameType = GameType.TEMP;
            Difficulty difficulty = Helpers.GetDifficultyEnum(difficultyChoice);
            char mathOperator;

            var timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += TickTime;
            timer.Start();
            for (int i = 0; i < 5; i++)
            {
                int answer;
                int a;
                int b;
                while (true)
                {
                    a = random.Next((int)Math.Pow(10,(double)difficultyChoice)+1);
                    b = random.Next((int)Math.Pow(10, (double)difficultyChoice)+1);
                    if (operatorChoice == 'x')
                    {
                        mathOperator = Helpers.GetRandomOperator();
                    }
                    else 
                    {
                        mathOperator = operatorChoice; 
                    }
                    var result = Helpers.CalculateAnswer(mathOperator, a, b);
                    answer = result.answer;
                    gameType = result.gameType;

                    if (answer > -1) 
                    {
                        break; 
                    }
                }
                Console.WriteLine($"\nWhat is {a}{mathOperator}{b}");
                var userAnswer = Helpers.AnswerValidation();

                if (userAnswer == answer)
                {
                    Console.WriteLine("Correct! +1 point!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect! No points!\n");
                }
            }
            timer.Stop();
            if (operatorChoice == 'x')
            {
                gameType = GameType.Random;
            }
            Helpers.AddToHistory(score, gameType, counter,difficulty);
            Console.WriteLine($"You scored {score} pts in {counter} seconds.\n" +
                $"Press any key to return to the menu.");
            Console.ReadKey(true);
            Console.Clear();
        }

        public void TickTime(object sender, EventArgs e)
        {
            counter++;
        }
        
    }
}
