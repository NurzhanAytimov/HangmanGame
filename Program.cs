using System;

namespace HangmanGame
{
    class Program
    {

        public static void Main(string[] args)
        {
            HangmanGame game = new HangmanGame();
            Console.WriteLine("Welcome to HangmanGame!");
            Console.WriteLine("Select category: ");
            Console.WriteLine("[1] Profession");
            Console.WriteLine("[2] Footballer");
            Console.WriteLine("[3] City");
            Console.WriteLine("[4] Animals");
            int select = int.Parse(Console.ReadLine());

            game.ChooseWord(select);
            Console.WriteLine($"Guess the word: {game.WordGenerate('*')}");

            while (game.status == Status.Progress)
            {
                Console.Write("Enter a letter: ");
                char letter = Console.ReadLine().ToLower()[0];
                string result = game.WordGenerate(letter);

                Console.WriteLine(result);

                if (game.status == Status.Won)
                {
                    Console.WriteLine("Congratulations! You won!");
                    break;
                }
                else if (game.status == Status.Lost)
                {
                    Console.WriteLine($"You lost! The word was: {game.word}");
                    break;
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
    
