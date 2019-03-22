using System;
using System.IO;

namespace WordGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }

        #region Main Menu
        /// <summary>
        /// This is method creates the main navigational menu.
        /// </summary>
        /// <returns>returns true if the user staying in the program or false to exit the program</returns>
        static bool MainMenu()
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
                    return true;
                } else if (choice == "2")
                {
                    Console.Clear();
                    Options();
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
        #region Game
        #endregion
        #region Options Menu
        static void Options()
        {
            bool menuReturn = true;
            while (menuReturn)
            {
                menuReturn = OptionsMenu();
            }
        }
        static bool OptionsMenu()
        {
            Console.WriteLine("Please enter the number for one of the following options.");
            Console.WriteLine("1) Display a list of the words");
            Console.WriteLine("2) Add a word");
            Console.WriteLine("3) Delete a word");
            Console.WriteLine("4) Exit Options Menu");

            string path = "../../../wordlist.txt";

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
        static string[] ReadWordList(string path)
        {
            

            string[] wordList = File.ReadAllLines(path);

            return wordList;
        }
        #endregion
        #region Display Word List
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

        #endregion
    }
}
