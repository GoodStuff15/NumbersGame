// Gustav Eriksson Söderlund, SUT24

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int[] difficulty = new int[] { 10, 20, 30, 50, 100 };
            string[] difficultyABC = new string[] { "Lätt", "Medel", "Besvärligt", "Jävligt", "Omöjligt" };
            int tries = 0;
            bool correct = false;

            Random r = new Random();

            

            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök, men först måste du välja svårighetsgrad!:");
            
            Console.WriteLine($"Skriv {difficultyABC[0]}, {difficultyABC[1]}, {difficultyABC[2]}, {difficultyABC[3]}, eller {difficultyABC[4]}");
            
            string userDiffChoice = Console.ReadLine();
            int diffIndex = Array.IndexOf(difficultyABC, userDiffChoice);
            int diffChoice = difficulty[diffIndex];

            int thinkingOf = r.Next(1, diffChoice);

            Console.WriteLine($"Du valde {userDiffChoice} som svårighetsgrad! Skriv in ett nummer mellan 1 och {diffChoice}:");
            Console.WriteLine($"Correct: {thinkingOf}");

            while (tries < 5 &! correct)
            { 

                int guess = Convert.ToInt32(Console.ReadLine());
                tries++;

                checkGuess(guess);

            }

            if (correct)
            {
                Console.WriteLine("Du vann! Vill du prova igen?");
            }
            else
            {
                Console.WriteLine("Bättre lycka nästa gång! Vill du spela igen?");
            }


            void checkGuess(int g)
            {
                if (g > thinkingOf && g > (thinkingOf +3))
                {
                    Console.Write("Tyvärr du gissade för högt! ");

                    if(tries < 5)
                    {
                        Console.Write("Prova igen!\n");
                    }
                }
                else if(g > thinkingOf && g <= (thinkingOf + 3))
                {
                    Console.Write("OOOH det var nära, men lite för högt! ");

                    if (tries < 5)
                    {
                        Console.Write("Prova igen!\n");
                    }
                }
                else if (g < thinkingOf && g < (thinkingOf - 3))
                {
                    Console.Write("Tyvärr du gissade för lågt! ");

                    if (tries < 5)
                    {
                        Console.Write("Prova igen!\n");
                    }
                }
                else if (g < thinkingOf && g >= (thinkingOf - 3))
                {
                    Console.Write("OOOH det var nära, men lite för Lågt! ");

                    if (tries < 5)
                    {
                        Console.Write("Prova igen!\n");
                    }
                }
                else if(g == thinkingOf)
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
