using System;

namespace Lab03_SYSTEMIO
{
    class Program
    {
        static void Main(string[] args)
        {
            NewGame();
        }

        static void HomeNav()
        {

        }

        static void ViewWords()
        {

        }

        static void AddWord()
        {

        }

        static void RemoveWord()
        {

        }

        static void NewGame()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("WELCOME TO JOSIE CAT'S GUESSING GAME!");
            Console.WriteLine("*************************************");
            Console.WriteLine("");
            Console.WriteLine("    Please press ENTER to begin.");
            Console.ReadLine();
        }

        static void ExitGame()
        {
            Console.WriteLine("Thank you for playing Josie Cat's Guessing Game!");
            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
