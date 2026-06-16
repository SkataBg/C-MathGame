namespace MathGame
{
    public class Menu
    {
        GameEngine game = new();
        char operatorChoice = 'x';
        int difficulty = '4';
        public void CreateMenu()
        {
            var watingForExitCommand = true;
            while (watingForExitCommand)
            {
                Console.Clear();
                Console.WriteLine("Welcome to my game! \n Press any key to continue!");
                Console.ReadKey(true);
                operatorChoice = Helpers.ChooseMathOperator();
      
                difficulty = Helpers.ChooseDifficulty();

                if (difficulty != 4)
                {
                    game.StartGame(operatorChoice, difficulty);
                }
            }
            
        }
    }
}