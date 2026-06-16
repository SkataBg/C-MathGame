using System;

public class Menu
{
    public Menu()
    public void CreateMenu()
    {
        while (true)
        {
            Console.WriteLine("Welcome to my game! \n Let's play!");
            Console.WriteLine("\n\nSelect an operation!");
            Console.WriteLine("1.[+]     2.[-]      3.[*]        4.[/]      0.[Exit]");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                return;
            }

            switch (keyInfo.KeyChar)
            {
                case '1':
                    Game('+');
                    break;
                case '2':
                    Game('-');
                    break;
                case '3':
                    Game('*');
                    break;
                case '4':
                    Game('/');
                    break;
                case '0':
                    return;
                default:
                    Console.WriteLine("\nPlease choose a valid option.\n");
                    break;
            }
        }
    }
}
