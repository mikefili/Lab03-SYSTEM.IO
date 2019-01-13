using System;
using System.IO;

namespace Lab03_SYSTEMIO
{
    class Program
    {
        private static string newWord;

        static void Main(string[] args)
        {
            HomeNav();
        }

        static void HomeNav()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("WELCOME TO JOSIE CAT'S GUESSING GAME!");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.WriteLine("    1) Play");
            Console.WriteLine("    2) Admin");
            Console.WriteLine("    3) Exit");
            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("  What would you like to do?");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.Write("Your Selection: ");

            string pick = Console.ReadLine();

            switch (pick)
            {
                // if user selects '1'
                case "1":
                    Console.WriteLine("OPTION 1");
                    Console.ReadLine();
                    break;

                // if user selects '2' 
                case "2":
                    AdminMenu();
                    break;

                // if user selects '3' 
                case "3":
                    Console.WriteLine("OPTION 3");
                    Console.ReadLine();
                    break;

            }
        }

        static void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("*************************************");
            Console.WriteLine("        GUESSING GAME ADMIN:");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.WriteLine("    1) View Words");
            Console.WriteLine("    2) Add Word");
            Console.WriteLine("    3) Remove Word");
            Console.WriteLine("    4) Exit");
            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("  What would you like to do?");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.Write("Your Selection: ");

            string adminPick = Console.ReadLine();

            switch (adminPick)
            {
                case "1":
                    Console.WriteLine("OPTION 1");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("OPTION 2");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.WriteLine("OPTION 3");
                    Console.ReadLine();
                    break;

                case "4":
                    Console.WriteLine("OPTION 4");
                    Console.ReadLine();
                    break;
            }
        }

        static void ViewWords()
        {

        }

        static void AddWord(string path)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    Console.WriteLine("What word would you like to add?");
                    Console.WriteLine();
                    Console.Write("New Word: ");
                    newWord = Console.ReadLine();

                    if (newWord == "")
                    {
                        Console.WriteLine("Sorry, provide a word.");
                        Console.WriteLine();
                    }
                    switch (newWord)
                    {

                    }
                }
            }
            catch
            {

            }
        }

        static void RemoveWord()
        {

        }

        static void NewGame()
        {
            
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
