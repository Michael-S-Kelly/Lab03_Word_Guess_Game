using System;

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
        #endregion
    }
}
