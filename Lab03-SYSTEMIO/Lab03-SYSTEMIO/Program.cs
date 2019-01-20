using System;
using System.IO;
using System.Linq;

namespace Lab03SYSTEMIO
{
    public class Program
    {
        // declare public variables including file paths
        public static string newWordRaw;
        public static string mysteryWord;
        public static bool correct = false;
        public static string path = ("../../../wordBank.txt");
        public static string attempts = ("../../../attempts.txt");

        // Main method
        public static void Main(string[] args)
        {
            // create word list at path above
            // while loop keeps game running until exit
            CreateWordList();
            bool runHomeNav = true;
            while (runHomeNav)
            {
                HomeNav();
            }
            ExitGame();
            
        }

        /// <summary>
        /// home navigation menu interface
        /// </summary>
        public static void HomeNav()
        {
            Console.Clear();
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

            // switch statement allows user to pick from three options
            switch (pick)
            {
                // if user selects '1' begin game w/ PlayGame method
                case "1":
                    PlayGame(mysteryWord);
                    break;

                // if user selects '2' open admin menu w/ AdminMenu method
                case "2":
                    AdminMenu();
                    break;

                // if user selects '3' exit app w/ ExitGame method
                case "3":
                    ExitGame();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// pass PlayGame method a mystery word and start game
        /// </summary>
        /// <param name="mysteryWord">mystery word from word bank</param>
        public static void PlayGame(string mysteryWord)
        {
            // get a random word from the word bank
            mysteryWord = RandomWord(path);
            // create a new attempts file & dispose of any existing file
            File.Create(attempts).Dispose();
            Console.Clear();
            // layout game board for player based on length of mystery word
            string[] gameBoard = new string[mysteryWord.Length];
            for (int i = 0; i < mysteryWord.Length; i++)
            {
                gameBoard[i] = "___ ";
                Console.Write($"{gameBoard[i]}");
            }
            // request guess from user
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Please enter a letter: ");
            // iterate through game board so long as letters remain to be guessed
            while (gameBoard.Contains("___ "))
            {
                // take in guess from user
                string guessedLetterRaw = Console.ReadLine();
                string guessedLetter = guessedLetterRaw.ToUpper();
                // confirm only one letter received
                if (guessedLetter.Length != 1)
                {
                    Console.WriteLine("One letter only, please.");
                }
                // use GuessValidator method to check for guessed letter in mystery word
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
                Console.Clear();
                // append guessed letter to attempts file
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
                Console.WriteLine();
                // display letters guessed so far
                string[] guesses = File.ReadAllLines(attempts);
                Console.WriteLine();
                Console.WriteLine("Guessed: ");
                for (int i = 0; i < guesses.Length; i++)
                {
                    Console.Write(guesses[i].ToUpper());
                }
                Console.WriteLine();
                Console.WriteLine();
                // request next guess from user
                Console.Write("Please enter a letter: ");
                Console.Write("");
            }
            // alert user that they've won the game!
            Console.Clear();
            Console.WriteLine("     ___.__. ____  __ __ ");
            Console.WriteLine("    <   |  |/  _ \\|  |  \\");
            Console.WriteLine("     \\___  (  <_> )  |  /");
            Console.WriteLine("     / ____|\\____/|____/");
            Console.WriteLine();
            Console.WriteLine("            .__");
            Console.WriteLine("    __  _  _|__| ____");
            Console.WriteLine("    \\ \\/ \\/ /  |/    \\");
            Console.WriteLine("     \\     /|  |   |  \\");
            Console.WriteLine("      \\/\\_/ |__|___|  /");
            Console.WriteLine("                    \\/");
            Console.WriteLine();
            Console.WriteLine("       _          ___");
            Console.WriteLine("     /' '\\       / \" \\");
            Console.WriteLine("    |  ,--+-----4 /   |");
            Console.WriteLine("    ',/   o  o     --.;");
            Console.WriteLine(" --._|_   ,--.  _.,-- \\----.");
            Console.WriteLine(" ------'--`--' '-----,'     |");
            Console.WriteLine("      \\_  ._\\_.   _,-'---._.'");
            Console.WriteLine("        `--...--``  /");
            Console.WriteLine("          /###\\   | |");
            Console.WriteLine("          |.   `.-'-'.");
            Console.WriteLine("         .||  /,     |");
            Console.WriteLine("        do_o00oo_,.ob");
            Console.WriteLine();
            Console.WriteLine("Press ENTER to return to the Main Menu");
            Console.ReadLine();
        }

        /// <summary>
        /// return a random word from the word bank
        /// </summary>
        /// <param name="path">path to word bank</param>
        /// <returns></returns>
        public static string RandomWord(string path)
        {
            Random random = new Random();
            string[] words = ReadFile(path);
            int randomIndex = random.Next(words.Length);
            return words[randomIndex];
        }

        /// <summary>
        /// check to see if the guessed letter is present in the mystery word
        /// </summary>
        /// <param name="mysteryWord">mytery word from word bank</param>
        /// <param name="guessedLetter">letter guessed by user</param>
        /// <returns></returns>
        public static bool GuessValidator(string mysteryWord, string guessedLetter)
        {
            string valid = "";
            for (int i = 0; i < mysteryWord.Length; i++)
            {
                if (mysteryWord[i].ToString() == guessedLetter)
                {
                    valid = valid + guessedLetter;
                }
            }
            if (valid != "") return true;
            else return false;
        }

        /// <summary>
        /// admin menu interface
        /// </summary>
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

            // switch statement allows user to pick from three options
            switch (adminPick)
            {
                // if user selects '1' display word bank
                case "1":
                    Console.Clear();
                    DisplayWords();
                    break;

                // if user selects '2' display add word interface
                case "2":
                    Console.Clear();
                    AddWord(path, ValidateInput());
                    Console.ReadLine();
                    break;

                // if user selects '3' display remove word interface
                case "3":
                    Console.Clear();
                    RemoveWord(path);
                    break;

                // if user selects '4' exit back to main menu
                case "4":
                    Console.Clear();
                    HomeNav();
                    break;
            }
        }

        /// <summary>
        /// create word bank file & fill it with an array of starter words
        /// </summary>
        /// <param name="path">path to word bank</param>
        public static void CreateWordList()
        {
            string[] words = { "dog", "puppy", "pooch", "pupper", "woofer" };
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                foreach (string word in words)
                {
                    streamWriter.WriteLine($"{word.ToUpper()}");
                }
            }
        }

        /// <summary>
        /// read all words currently in word bank & write each on a new line
        /// </summary>
        /// <param name="path">path to word bank</param>
        /// <returns>words currently in word bank</returns>
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

        /// <summary>
        /// display all words currently in word bank & allow user to return
        /// to admin menu after
        /// </summary>
        public static void DisplayWords()
        {
            ReadFile(path);
            Console.WriteLine();
            Console.WriteLine("Press ENTER to return to the Admin Menu");
            Console.ReadLine();
            AdminMenu();
        }

        public static string ValidateInput()
        {
            try
            {
                Console.WriteLine("What word would you like to add?");
                Console.WriteLine();
                Console.Write("New Word: ");
                string newWord = Console.ReadLine();
                newWord = newWord.ToUpper();
                return newWord;
            }
            catch (ArgumentNullException)
            {
                return "Please enter a word.";
            }
            catch (Exception)
            {
                return "An error occurred";
            }
        }

        /// <summary>
        /// add a new word to the word bank
        /// </summary>
        /// <param name="path">path to word bank</param>
        public static string AddWord(string path, string newWord)
        {
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(newWord);
            }
            Console.WriteLine($"You have successfully added the word: {newWord}");
            Console.WriteLine("Press ENTER to return to the Main Menu");
            return newWord;
        }

        /// <summary>
        /// remove a word from the word bank
        /// </summary>
        /// <param name="path">path to word bank</param>
        public static void RemoveWord(string path)
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

        /// <summary>
        /// file deletion handler
        /// </summary>
        /// <param name="path">path to word bank</param>
        public static void DeleteFile(string path)
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

        /// <summary>
        /// exit the game
        /// </summary>
        public static void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing Josie Cat's Guessing Game!");
            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
