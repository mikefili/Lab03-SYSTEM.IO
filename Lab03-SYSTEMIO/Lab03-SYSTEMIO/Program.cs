using System;
using System.IO;
using System.Linq;

namespace Lab03_SYSTEMIO
{
    class Program
    {
        public static string newWord;
        public static string mysteryWord;
        public static bool correct = false;
        public static string path = ("../../../wordBank.txt");
        public static string attempts = ("../../../attempts.txt");

        static void Main(string[] args)
        {
            CreateWordList(path);
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
                    PlayGame(mysteryWord);
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

        public static void PlayGame(string mysteryWord)
        {
            Console.Clear();
            mysteryWord = RandomWord(path);
            //File.Create(attempts).Dispose();
            string[] gameBoard = new string[mysteryWord.Length];
            for (int i = 0; i < mysteryWord.Length; i++)
            {
                gameBoard[i] = "___ ";
                Console.Write($"{gameBoard[i]}");
            }
            Console.WriteLine("please enter a letter");
            while (gameBoard.Contains("___ "))
            {
                string guessedLetter = Console.ReadLine();
                if (guessedLetter.Length != 1)
                {
                    Console.WriteLine("please press one letter");
                }
                bool result = GuessValidator(mysteryWord, guessedLetter);
                if (result == true)
                {
                    for (int i = 0; i < mysteryWord.Length; i++)
                    {
                        if (mysteryWord[i].ToString() == guessedLetter)
                        {
                            int guessIndex = mysteryWord.IndexOf(guessedLetter);
                            gameBoard[i] = mysteryWord[i].ToString();
                        }
                    }
                }
                try
                {
                    using (StreamWriter streamWriter = File.AppendText(attempts))
                    {
                        streamWriter.WriteLine(guessedLetter);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: '{0}'", e);
                }
                for (int i = 0; i < gameBoard.Length; i++)
                {
                    Console.Write($"{gameBoard[i]}");
                }
                Console.Write("    ");
                string[] lines = File.ReadAllLines(attempts);
                Console.WriteLine("Guessed: ");
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }
            }
            Console.WriteLine("       ___.__. ____  __ __ ");
            Console.WriteLine("      <   |  |/  _ \\|  |  \\");
            Console.WriteLine("       \\___  (  <_> )  |  /");
            Console.WriteLine("       / ____|\\____/|____/");
            Console.WriteLine();
            Console.WriteLine("              .__");
            Console.WriteLine("      __  _  _|__| ____");
            Console.WriteLine("      \\ \\/ \\/ /  |/    \\");
            Console.WriteLine("       \\     /|  |   |  \\");
            Console.WriteLine("        \\/\\_/ |__|___|  /");
            Console.WriteLine("                      \\/");

        }

        static string RandomWord(string path)
        {
            Random random = new Random();
            string[] words = ReadFile(path);
            int randomIndex = random.Next(words.Length);
            return words[randomIndex];
        }

        public static bool GuessValidator(string mysteryWord, string guessedLetter)
        {
            string temp = "";
            for (int i = 0; i < mysteryWord.Length; i++)
            {
                if (mysteryWord[i].ToString() == guessedLetter)
                {
                    temp = temp + guessedLetter;
                }
            }
            if (temp != "") return true;
            else return false;
        }

        public static string[] UpdateFile(string path, string input)
        {
            string formattedInput = input.ToUpper();

            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(formattedInput);
            }
            return ReadFile(path);
        }

        public static char[] WordValidator(string word)
        {
            int wordLength = word.Length;
            char[] character = new char[wordLength];
            for (int i = 0; i < wordLength; i++)
            {
                character[i] = '_';
            }

            string[] attemptedLetters = File.ReadAllLines(attempts);
            char[] attemptedChar = new char[attemptedLetters.Length];
            for (int i = 0; i < attemptedLetters.Length; i++)
            {
                attemptedChar[i - 1] = Convert.ToChar(attemptedLetters[i]);
            };
            for (int i = 0; i < attemptedLetters.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j] == attemptedChar[i])
                    {
                        character[j] = word[j];
                    }
                }
            }
            return character;
        }

        public static string TakeInGuess()
        {
            Console.Write("Guess a Letter: ");
            string guessedLetterRaw = Console.ReadLine();
            string guessedLetter = guessedLetterRaw.ToUpper();
            return guessedLetter;
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
                    Console.Clear();
                    ReadFile(path);
                    break;

                case "2":
                    Console.Clear();
                    AddWord(path);
                    break;

                case "3":
                    Console.Clear();
                    RemoveWord(path);
                    break;

                case "4":
                    Console.Clear();
                    HomeNav();
                    break;
            }
        }

        public static void CreateWordList(string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                string[] words = { "dog", "puppy", "pooch", "pupper", "woofer" };
                try
                {
                    foreach (string word in words)
                    {
                        streamWriter.WriteLine($"{word}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: '{0}'", e);
                }
            }
        }

        public static void CreateGuessList()
        {
            using (StreamWriter streamWriter = new StreamWriter(attempts))
            {
                streamWriter.WriteLine("Your Attempts: ");
            }
        }

        public static string[] ReadFile(string path)
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

        public static void DisplayWords()
        {
            ReadFile(path);
            Console.WriteLine();
            AdminMenu();
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
            string[] words = ReadFile(path);
            Console.WriteLine("Which word would you like to delete?");
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
            DisplayWords();
            AdminMenu();
        }

        static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
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
