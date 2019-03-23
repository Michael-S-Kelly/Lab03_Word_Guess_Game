using System;
using System.IO;

namespace WordGuessingGame
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            string path = "../../../wordlist.txt";
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu(path);
            }
        }
        #endregion
        #region Main Menu
        /// <summary>
        /// This is method creates the main navigational menu.
        /// </summary>
        /// <returns>returns true if the user staying in the program or false to exit the program</returns>
        static bool MainMenu(string path)
        {
            Console.Clear();
            Console.WriteLine("Please enter a number from one of the following options");
            Console.WriteLine("1) Play Word Guessing Game");
            Console.WriteLine("2) Options");
            Console.WriteLine("3) Exit");

            try
            {
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Clear();
                    StartGame(path);
                    return true;
                } else if (choice == "2")
                {
                    Console.Clear();
                    Options(path);
                    return true;
                } else if (choice == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Thank you for playing the Word Guessing Game");
                    Console.WriteLine("Please press enter to exit.");
                    Console.ReadLine();
                    return false;
                } else
                {
                    Console.Clear();
                    Console.WriteLine("That is not a leginimate option.");
                    Console.WriteLine("Please press enter to try again.");
                    Console.ReadLine();
                    return true;
                }
            }
            catch (IndexOutOfRangeException IOREx)
            {
                Console.Clear();
                Console.WriteLine("There was an 'Index Out Of Range error in the MainMenu method");
                Console.WriteLine(IOREx.Message);
                Console.ReadLine();
                throw;
            }
            catch (Exception genEx)
            {
                Console.Clear();
                Console.WriteLine("There was a problem in the MainMenu method");
                Console.WriteLine(genEx.Message);
                Console.WriteLine("Please press enter to try again.");
                Console.ReadLine();
                throw;
            }
        }
        #endregion
        #region Start Game
        /// <summary>
        /// This is the method that sets up the game by choosing the word to guess through the ChooseWord method, sets up the variables for and passes to the PlayGame method
        /// </summary>
        /// <param name="path">This variable passes the path to the text file that holds the available words to the ChooseWord method</param>
        static void StartGame(string path)
        {
            try
            {
                string word = ChooseWord(path);
                char[] letters = word.ToCharArray();
                char[] guessLetters = new char[letters.Length];
                for (int i = 0; i < guessLetters.Length; i++)
                {
                    guessLetters[i] = '_';
                }
                PlayGame(letters, guessLetters, word);
            }
            catch (Exception genEx)
            {
                Console.WriteLine("There was a problem in the StartGame method.");
                Console.WriteLine(genEx.Message);
                Console.WriteLine("Please press enter to try again.");
                Console.ReadLine();
                throw;
            }
        }
        #endregion
        #region Play Game
        /// <summary>
        /// This method is the main method for the actual game.  It takes user guess of a letter as an input to update the guessLetters array and sends that array to the CheckForWin method
        /// </summary>
        /// <param name="letters">This array is a list of the letters in the chosen word</param>
        /// <param name="guessLetters">This array is all '_' equal to the number of indexes in the letters array</param>
        /// <param name="word">This is the string of the chosen word that the letters array is based off of</param>
        static void PlayGame(char[] letters, char[] guessLetters, string word)
        {
            try
            {
                int tries = 0;
                int lettersGuessed = 0;
                int totalletters = letters.Length;
                while (totalletters != lettersGuessed)
                {
                    Console.Clear();
                    if (tries == 1)
                    {
                        Console.WriteLine($"So far, you have made {tries} guess.");
                    } else if (tries > 1)
                    {
                        Console.WriteLine($"So far, you have made {tries} guesses.");
                    }

                    Console.WriteLine("Please enter a letter to guess one of the letters in the word bellow.");
                    for (int i = 0; i < guessLetters.Length; i++)
                    {
                        Console.Write(guessLetters[i]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    string longGuess = Console.ReadLine();
                    char[] multGuess = longGuess.ToCharArray();
                    char guess = multGuess[0];
                    for (int j = 0; j < letters.Length; j++)
                    {
                        if (letters[j] == guess)
                        {
                            guessLetters[j] = guess;
                        }
                    }
                    tries++;
                    lettersGuessed = CheckForWin(letters, guessLetters);
                }

                EndGame(word, tries);

            }
            catch (Exception genEx)
            {
                Console.WriteLine("There was a problem in the PlayGame method.");
                Console.WriteLine(genEx.Message);
                Console.WriteLine("Please press enter to try again.");
                Console.ReadLine();
                throw;
            }
        }
        #endregion
        #region End Game
        /// <summary>
        /// This is the method that is called once the user finishes guessing the word
        /// </summary>
        /// <param name="word">this is the string for the choosen word passed from the ChooseWord method</param>
        /// <param name="tries">this is the number of tries that the user took in order to guess the word</param>
        static void EndGame(string word, int tries)
        {
            Console.Clear();
            Console.WriteLine($"Congratulations, you have guessed the word '{word}' in {tries} guesses.");
            Console.WriteLine("Please press enter to return to the main menu.");
            Console.ReadLine();
            
        }
        #endregion
        #region Choose Word
        /// <summary>
        /// This pulls the list of words from the ReadWordList method and chooses a random word for the game
        /// </summary>
        /// <param name="path">this is the path to the text file passed from the Main method</param>
        /// <returns>this returns the choosen random word from the list of words in the text file</returns>
        static string ChooseWord(string path)
        {
            string[] wordList = ReadWordList(path);
            Random rand = new Random();
            string word = wordList[rand.Next(wordList.Length)];
            return word;
        }
        #endregion
        #region Check For Win
        /// <summary>
        /// This method takes in the letters and guessLetters arrays to compare them and count the number of indexes that are the same
        /// </summary>
        /// <param name="letters">This is an array of letters created from the string word from the StartGame method</param>
        /// <param name="guessLetters">This is an array that starts off full of '_' and is updated in the PlayGame method bassed on user guesses</param>
        /// <returns>This is the number of indexes that are equal to each other between the letters and guessLetters array</returns>
        static int CheckForWin(char[] letters, char[] guessLetters)
        {
            int lettersGuessed = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == guessLetters[i])
                {
                    lettersGuessed++;
                }
            }
            return lettersGuessed;
        }
        #endregion
        #region Options Menu
        /// <summary>
        /// This method is used to navigate through displaying a list of the words in the text file, adding words to the text file, and removing a word from the text file
        /// </summary>
        /// <param name="path">this is the path to the text file passed from the Main method</param>
        static void Options(string path)
        {
            bool menuReturn = true;
            while (menuReturn)
            {
                menuReturn = OptionsMenu(path);
            }
        }
        static bool OptionsMenu(string path)
        {
            Console.WriteLine("Please enter the number for one of the following options.");
            Console.WriteLine("1) Display a list of the words");
            Console.WriteLine("2) Add a word");
            Console.WriteLine("3) Delete a word");
            Console.WriteLine("4) Exit Options Menu");



            try
            {
                CheckFile(path);

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    DisplayWordList(path);

                    return true;
                }
                else if (choice == "2")
                {
                    AddWord(path);
                    return true;
                }
                else if (choice == "3")
                {
                    DeleteWord(path);
                    return true;
                }
                else if (choice == "4")
                {
                    return false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("That is not a leginimate option.");
                    Console.WriteLine("Please press enter to try again.");
                    Console.ReadLine();
                    return true;
                }
            }
            catch (Exception genEx)
            {
                Console.Clear();
                Console.WriteLine("There was a problem in the OptionsMenu method");
                Console.WriteLine(genEx.Message);
                Console.WriteLine("Please press enter to try again.");
                Console.ReadLine();
                throw;
            }
        }
        #endregion
        #region Check File
        /// <summary>
        /// This method checks to see if the wordlist text file is there bassed on the path sent from the Main method
        /// </summary>
        /// <param name="path">This is the path string to give the location to the text file from the Main method</param>
        static void CheckFile(string path)
        {
            if (File.Exists(path))
            {

            }
            else
            {
                CreateFile(path);
            }
        }
        #endregion
        #region Create File
        /// <summary>
        /// If the CheckFile method finds that there isn't a starter text file, this method creates one with a starter list of words
        /// </summary>
        /// <param name="path">This is the path string to give the location to the text file from the Main method</param>
        static void CreateFile(string path)
        {

            string[] words = { "beginner", "school", "crescendo" };

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string line in words)
                {
                    sw.WriteLine(line);
                }
            }
        }
        #endregion
        #region Read StreamReader
        /// <summary>
        /// This method creates a string of words from the wordlist text file
        /// </summary>
        /// <param name="path">This is the path string to give the location to the text file from the Main method</param>
        /// <returns></returns>
        static string[] ReadWordList(string path)
        {
            

            string[] wordList = File.ReadAllLines(path);

            return wordList;
        }
        #endregion
        #region Display Word List
        /// <summary>
        /// This method is used to display a list of the words in the array created in the ReadWordList method
        /// </summary>
        /// <param name="path">This is the path string to give the location to the text file from the Main method</param>
        static void DisplayWordList(string path)
        {
            Console.WriteLine("");
            Console.WriteLine("");

            string[] words = ReadWordList(path);
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }
        #endregion
        #region Add Word
        /// <summary>
        /// This method adds an user inputted word to the wordlist text file
        /// </summary>
        /// <param name="path">This is the path string to give the location to the text file from the Main method</param>
        static void AddWord(string path)
        {
            Console.WriteLine("Please enter the word that you wish to add.");
            
            using (StreamWriter sw = File.AppendText(path))
            {
                string word = Console.ReadLine();
                sw.WriteLine(word);
            }
        }
        #endregion
        #region Delete Word
        /// <summary>
        /// This method deletes an user inputted word from the wordlist text file
        /// </summary>
        /// <param name="path">This is the path string to give the location to the text file from the Main method</param>
        static void DeleteWord(string path)
        {
            Console.WriteLine("Please enter the word you wish to remove from the game list.");

            string deleteWord = Console.ReadLine();

            string[] wordList = ReadWordList(path);
            File.WriteAllText(path, String.Empty);
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string word in wordList)
                {
                    if (!word.Equals(deleteWord))
                    {
                        sw.WriteLine(word);
                    }
                }
            }
        }

        #endregion
    }
}
