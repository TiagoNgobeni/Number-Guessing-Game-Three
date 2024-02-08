using System;

namespace guessingGameThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int cpuGuess = rnd.Next(1,11);

            int playerGuess;
            const int MAX_ATTEMPTS = 7;
            int numberOfAttempts = 0;
            bool outOfAttempts = false;
            Nullable<int> lastPlayerGuess = null;

            Console.Write("Please enter your name:: ");
            string playerName = Console.ReadLine();

            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

            Console.Write("Welcome {0}, would you like to play a guessing game? ",playerName);
            Console.WriteLine("(Y/N):: ");
            string startGame = Console.ReadLine();

            switch(startGame.ToUpper())
            {
                case "Y":
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                    Console.WriteLine("Welcome to the guessing game. You are given 8 attempts to guess the correct number. Good Luck!");
                    Console.Write("Guess any number between 1 and 10:: ");
                    playerGuess = int.Parse(Console.ReadLine());

                    while (playerGuess != cpuGuess)
                    {
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                        //Console.WriteLine(cpuGuess);

                        if (numberOfAttempts == MAX_ATTEMPTS)
                        {
                            outOfAttempts = true;
                            break;
                        }

                        if (playerGuess < 0 || playerGuess > 10)
                        {
                            Console.WriteLine("You guessed out of range!");
                        }
                        else if (playerGuess < cpuGuess)
                        {
                            Console.WriteLine("You guessed too low!");
                            if (playerGuess < lastPlayerGuess)
                            {
                                Console.WriteLine("You should have known not to make such a lower guess!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You guessed too high!");
                            if (playerGuess > lastPlayerGuess)
                            {
                                Console.WriteLine("You should have known not to make such a higher guess!");
                            }
                        }

                        lastPlayerGuess = playerGuess;
                        numberOfAttempts++;

                        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                        Console.Write("Come on {0} you can do this. Guess again:: ",playerName);
                        playerGuess = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine(" ");
                    if (outOfAttempts)
                    {
                        Console.WriteLine("Unfortunately {0}, you have ran out of attempts.",playerName);
                    }
                    else
                    {
                        Console.WriteLine("Congratulations {0}, you guessed correctly in {1} attempt's!! you should Lotto!",playerName,numberOfAttempts);
                    }
                    break;
                case "N":
                    Console.WriteLine("Have a good day! {0}",playerName);
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again and press Y for yes and N for no!");
                    break;
            }
            
            Console.ReadKey();
        }
    }
}