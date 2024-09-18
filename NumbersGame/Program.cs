﻿// Gustav Eriksson Söderlund, SUT24

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Arrays that contain difficulty name and number

            int[] difficulty = new int[] { 10, 20, 30, 50, 100 };
            string[] difficultyABC = new string[] { "Lätt", "Medel", "Besvärligt", "Jävligt", "Omöjligt" };

            // a string that contains the index of the last value in the above string
            // and the string at that value
            // These are used for formatting and for readability of the foreach loop below

            int abcSize = difficultyABC.Count() -1;
            string lastDifficulty = difficultyABC[abcSize];

            // Variables that contain user guess, number of guesses, if the answer is correct
            // and if the game is running. Also a random object.
            int tries = 0;
            int maxTries = 5;
            int guess;
            bool correct = false;
            bool running = true;
            
            Random r = new Random();
           

     while(running)
            {


            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök, men först måste du välja svårighetsgrad!\n" +
                "Skriv in ditt val:");

            // Loops trough the difficulties to print their names to the console.
            // The if-statement is for formatting only.

                foreach(string d in difficultyABC)
                {
                    if(d == lastDifficulty)
                    {
                        Console.Write($"eller {d}.\n");
                    }
                    else

                    {
                        Console.Write($"{d}, ");
                    }
                }
          
            // The user enters their choice of difficulty
            // Then code makes sure that the max value that will be
            // guessed matches the difficulty name (same index).

            string userDiffChoice = Console.ReadLine();
            int diffIndex = Array.IndexOf(difficultyABC, userDiffChoice);
            int diffChoice = difficulty[diffIndex];

            int thinkingOf = r.Next(1, diffChoice+1);
            
                // Prints what numbers the user can guess between.

            Console.WriteLine($"Du valde {userDiffChoice} som svårighetsgrad! Skriv in ett nummer mellan 1 och {diffChoice}:");
            Console.WriteLine($"Correct: {thinkingOf}");

                // A while loop that continues as long as the user
                // has less than 5 tries and is NOT correct.
                // Each loop the user can make a new guess, 
                // A call to the CheckGuess function has the user guess
                // and the correct answer as OGABOGA

            while (tries < 5 &! correct)
            { 

                guess = Convert.ToInt32(Console.ReadLine());
                tries++;

                CheckGuess(guess, thinkingOf);

            }

            // When the while loop is exited, this if statement checks if the user
            // has made a correct guess or not.
            // It then asks if the user wants to continue, and calls the
            // Quit method using user input.

            if (correct)
            {
                Console.WriteLine("Du vann! Vill du prova igen? Svara Yes eller tryck på Enter för att avsluta.");
                    running = Quit(Console.ReadLine());
                    Console.Clear();

            }
            else
            {
                Console.WriteLine("Bättre lycka nästa gång! Vill du spela igen? Svara Yes eller tryck på Enter för att avsluta.");
                    running = Quit(Console.ReadLine());
                    Console.Clear();
                }

            }

            // A small method to reset the game if the user wants to keep playing.

            bool Quit(string no)
            {
                if(no.ToUpper() == "YES")
                {
                    correct = false;
                    tries = 0;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // The CheckGuess method uses if/else statements to check
            // if the user guess was right, wrong or wrong and close (within 3 numbers)
            // If the user has guesses left, it prints the number of tries left.

            void CheckGuess(int g, int a)
            {
                if (g > a && g > (a +3))
                {
                    Console.Write("Tyvärr du gissade för högt! ");

                    if(tries < maxTries)
                    {
                        Console.Write("Prova igen!\n");
                        Console.WriteLine($"{maxTries - tries} gissningar kvar.");
                    }
                }
                else if(g > a && g <= (a + 3))
                {
                    Console.Write("OOOH det var nära, men lite för högt! ");

                    if (tries < maxTries)
                    {
                        Console.Write("Prova igen!\n");
                        Console.WriteLine($"{maxTries - tries} gissningar kvar.");
                    }
                }
                else if (g < a && g < (a - 3))
                {
                    Console.Write("Tyvärr du gissade för lågt! ");

                    if (tries < maxTries)
                    {
                        Console.Write("Prova igen!\n");
                        Console.WriteLine($"{maxTries - tries} gissningar kvar.");
                    }
                }
                else if (g < a && g >= (a - 3))
                {
                    Console.Write("OOOH det var nära, men lite för Lågt! ");

                    if (tries < maxTries)
                    {
                        Console.Write("Prova igen!\n");
                        Console.WriteLine($"{maxTries - tries} gissningar kvar.");
                    }
                }
                else if(g == a)
                {
                    Console.WriteLine("Wohoo! Du gjorde det!");
                    correct = true;
                }
                else
                {
                    Console.WriteLine("Något gick fel :(");
                }
            }

        }
    }
}
