using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    public class HangmanGame
    {
        private readonly int lives = 6;
        private int count = 0;
        //bool openAny;
        public string word { get; private set;}

        public Status status = Status.Progress;
        bool[] opens;

        string[] animasl = { "lion", "tiger", "koala", "giraffe", "elephant", "hippopotamus", "rhinoceros", "hyena", "mouse", "boar", "cat", "dog" };
        string[] city = { "astana", "almaty", "moskow", "kiyev", "minsck", "toronto", "amsterdam", "karaganda", "ekaterinburg", "zurich", "bishkek", "pekin", "shanghai", "rim", "milan" };
        string[] proffesions = { "waiter", "manager", "operator", "security", "develoveper", "oilman", "driver", "driver", "model", "actor", "salesman" };
        string[] footbalers = { "messi", "ronaldo", "casillas", "rooney", "backham", "neymar", "mbappe", "ramos", "pepe", "suares" };

        //метод для генерации случайных слов
        public void ChooseWord(int select)
        {
            Random random = new Random();

            if (select == 1)
            {
                int rand = random.Next(footbalers.Length);
                word = footbalers[rand];
            }
            else if (select == 2)
            {
                int rand = random.Next(proffesions.Length);
                word = proffesions[rand];
            }
            else if(select == 3){
                int rand = random.Next(city.Length);
                word = city[rand];
            }
            else if (select == 4)
            {
                int rand = random.Next(animasl.Length);
                word = animasl[rand];

            }

            else
            {
                throw new InvalidOperationException("Invalid selection.");
            }

            opens = new bool[word.Length];
            status = Status.Progress;
        }
        //метод для генерации и открытия букв
        public string WordGenerate(char letter)
        {
            string result = string.Empty;
            bool openAny = false;

            if (count == lives)
            {
                throw new InvalidOperationException("You lose!");
            }

            if (status != Status.Progress)
            {
                throw new InvalidOperationException("Game not started!");
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                {
                    opens[i] = true;
                    openAny = true;
                }
                else if (opens[i])
                {
                    result += word[i];
                }
                else
                {
                    result += "*";
                }
            }

            if (!openAny)
                count++;

            if (Winner())
            {
                status = Status.Won;
            }
            else if (count == lives)
            {
                status = Status.Lost;
            }

            return result;

        }
        //метод для определение выигрыша
        private bool Winner()
        {
            foreach(var index in opens)
            {
                if (!index)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
