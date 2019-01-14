using System;
using System.IO;

namespace Lab03_SYSTEMIO
{
    class Program
    {
        private static string newWord;
        public static string path = ("../../../wordBank.txt");
        string[] words = { "dog", "puppy", "pooch", "pupper", "woofer" };

        static void Main(string[] args)
        {
            bool runHomeNav = true;
            while (runHomeNav)
            {
                HomeNav();
            }
            ExitGame();
            
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
            Console.WriteLine("    What would you like to do?");
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
                    ExitGame();
                    break;

            }
        }

        static void PlayGame(string path)
        {

        }

        static string RandomWord(string path)
        {
            Random random = new Random();
            string[] words = ViewWords(path);
            int selectedIndex = random.Next(words.Length);
            return words[selectedIndex];
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
            Console.WriteLine("     What would you like to do?");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.Write("Your Selection: ");

            string adminPick = Console.ReadLine();

            switch (adminPick)
            {
                case "1":
                    ViewWords(path);
                    break;

                case "2":
                    AddWord(path);
                    break;

                case "3":
                    RemoveWord(path);
                    break;

                case "4":
                    Console.Clear();
                    HomeNav();
                    break;
            }
        }

        public static string[] ViewWords(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string[] readWords = File.ReadAllLines(path);
                foreach (string readWord in readWords)
                {
                    Console.WriteLine(readWord);
                }
                return readWords;
            }
        }

        static void AddWord(string path)
        {
            try
            {
                Console.WriteLine("What word would you like to add?");
                Console.WriteLine();
                Console.Write("New Word: ");
                newWord = Console.ReadLine();
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine(newWord);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
        }

        static void RemoveWord(string path)
        {
            string[] words = ViewWords(path);
            Console.WriteLine("\nWhich word would you like to delete?");
            string toDeleteRaw = Console.ReadLine();
            string toDelete = toDeleteRaw.ToUpper();
            string[] newWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                if (toDelete != words[i])
                {
                    newWords[i] = words[i];
                }
                if (newWords == words)
                {
                    Console.WriteLine("That's not one of the words!");
                    AdminMenu();
                }
            }
            DeleteFile(path);
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                foreach (string word in newWords)
                {
                    streamWriter.WriteLine(word);
                }
            }
            Console.WriteLine("Remaining words: ");
            ViewWords(path);
            AdminMenu();
        }

        static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception)
            {

                throw;
            }
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
