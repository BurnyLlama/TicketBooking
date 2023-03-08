using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking
{
    internal class Menu
    {
        /// <summary>
        /// Pad the left of a string (or something else .toString()-able) with spaces so that it reaches a wished length.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="wishedLength"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        static string PadLeft<T>(T input, int wishedLength)
        {
            if (input == null)
            {
                throw new NullReferenceException("Generic T input is null!");
            }

            string str = input.ToString();
            if (str == null)
            {
                throw new NullReferenceException("String str is null!");
            }

            if (str.Length > wishedLength)
            {
                throw new ArgumentOutOfRangeException("String is too long!");
            }

            int padLength = wishedLength - str.Length;
            string padding = new string(' ', padLength);

            return $"{padding}{str}";
        }

        /// <summary>
        /// Gives the user a question an lists and arbritary amount of options.
        /// The user then has to select one, and the index of that option will be returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="question"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static int ChooseOne<T>(string question, T[] options)
        {
            Console.WriteLine(question);

            // Get the length of the largest number that will be printed.
            // Add 1 to make sure every line starts with at least 1 space.
            int wishedLength = (options.Length + 1).ToString().Length + 1;

            for (int i = 0; i < options.Length; i++)
            {
                string option = options[i].ToString();
                int optionNumber = i + 1;
                Console.WriteLine($"{PadLeft(optionNumber, wishedLength)}: {option}");
            }

            Console.Write("Your choice: ");

            // Grab input from the user.
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    int choice = int.Parse(input);

                    // Ask for a new choice if the choice is too high.
                    if (choice > options.Length || choice < 1)
                    {
                        Console.WriteLine("\nYour choice is out of range. Please try again.");
                        Console.Write("Your choice: ");
                        continue;
                    }

                    // Return choice - 1 because the list presented to the user is 1-indexed.
                    return choice - 1;
                }
                // Ask for a new choice if something went wrong.
                catch
                {
                    Console.WriteLine("\nInvalid choice! Please try again.");
                    Console.Write("Your choice: ");
                    continue;
                }
            }
        }

        /// <summary>
        /// Gives the user a question an lists and arbritary amount of options.
        /// The user then has to select one, and the index of that option will be returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="question"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static int ChooseOne<T>(string question, List<T> options)
        {
            Console.WriteLine(question);

            // Get the length of the largest number that will be printed.
            // Add 1 to make sure every line starts with at least 1 space.
            int wishedLength = (options.Count + 1).ToString().Length + 1;

            for (int i = 0; i < options.Count; i++)
            {
                string option = options[i].ToString();
                int optionNumber = i + 1;
                Console.WriteLine($"{PadLeft(optionNumber, wishedLength)}: {option}");
            }

            Console.Write("Your choice: ");

            // Grab input from the user.
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    int choice = int.Parse(input);

                    // Ask for a new choice if the choice is too high.
                    if (choice > options.Count || choice < 1)
                    {
                        Console.WriteLine("\nYour choice is out of range. Please try again.");
                        Console.Write("Your choice: ");
                        continue;
                    }

                    // Return choice - 1 because the list presented to the user is 1-indexed.
                    return choice - 1;
                }
                // Ask for a new choice if something went wrong.
                catch
                {
                    Console.WriteLine("\nInvalid choice! Please try again.");
                    Console.Write("Your choice: ");
                    continue;
                }
            }
        }

        /// <summary>
        /// Let the user choose a number between min and max.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int AskNumber(string question, int min, int max)
        {
            Console.WriteLine(question);
            Console.Write("Your choice: ");

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    int choice = int.Parse(input);

                    if (choice < min)
                    {
                        Console.WriteLine("\nYour choice is too low! Please try again.");
                        Console.Write("Your choice: ");
                        continue;
                    }

                    if (choice > max)
                    {
                        Console.WriteLine("\nYour choice is too high! Please try again.");
                        Console.Write("Your choice: ");
                        continue;
                    }

                    return choice;
                }
                catch
                {
                    Console.WriteLine("\nInvalid choice! Please try again.");
                    Console.Write("Your choice: ");
                    continue;
                }
            }
        }

        /// <summary>
        /// Ask the user for a string.
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public static string AskString(string question)
        {
            Console.WriteLine(question);
            Console.Write("Your choice: ");

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input == null)
                    {
                        Console.WriteLine("\nInvalid choice! Please try again.");
                        Console.Write("Your choice: ");
                        continue;
                    }

                    return input;
                }
                catch
                {
                    Console.WriteLine("\nInvalid choice! Please try again.");
                    Console.Write("Your choice: ");
                    continue;
                }
            }
        }
    }
}
