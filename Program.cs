using System.Drawing;
using System.Threading.Channels;

namespace Contest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] answers = { 99, 97, 98, 97, 97, 99, 99, 97, 97, 97 };

            void check_answer(ConsoleKeyInfo key, ref int question_number, ref int score)
            {
                if (answers[question_number] == key.KeyChar)
                {
                    RightAnswers(question_number);
                    score += 10;
                    return;
                }
                WrongAnswers(question_number);
                score -= 10;
                Question(question_number);
                Console.Clear();
                return;
            }
            string[,] questions = new string[10, 4] {
            { "1) How many colours are there in the rainbow?", "A) 4", "B) 8", "C) 7" },
            { "2) How many continents are there in the world?", "A) 7", "B) 2", "C) 5" },
            { "3) What is the capital of USA?", "A) New York", "B) Washington", "C) Los Angeles" },
            { "4) What is the largest planet in the universe?", "A) Jupiter", "B) Uranus", "C) Mars" },
            { "5) Which ocean bounds with South America from the west?", "A) Atlantic", "B) Pacific", "C) Indian" },
            { "6) How many eyes does a spider have?", "A) 2", "B) 1", "C) 8" },
            { "7) Which Turkish city shares Asia and Europe?", "A) Izmir", "B) Ankara", "C) Istanbul" },
            { "8) Who won the third football world cup in 1938?", "A) Italy", "B) France", "C) Portugal" },
            { "9) How many seas in the world?", "A) 5", "B) 3", "C) 7" },
            { "10) How many countries are there in Europe?", "A) 50", "B) 30", "C) 60" }};
            var textColor = "red";

            void Question(int number)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine(questions[number, i]);
                }
            }

            void WrongAnswers(int question_number)
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), textColor = "red", true);
                Console.Clear();
                Question(question_number);
                Console.WriteLine("Unfortunately, your answer was wrong! Press enter and try it again.");
                ConsoleKeyInfo key1 = Console.ReadKey();
                if (key1.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), textColor = "white", true);
                }
            }

            void RightAnswers(int question_number)
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), textColor = "green", true);
                Console.Clear();
                Question(question_number);
                Console.WriteLine("Well done! Press enter if you want to continue.");
                ConsoleKeyInfo key3 = Console.ReadKey();
                if (key3.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), textColor = "white", true);
                }
            }
            bool choice = true;
            int score = 0;
            while (choice == true)
            {
                Console.Clear();
                int question_number = 0;
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), textColor = "white", true);

                while (question_number != 10)
                {
                    Question(question_number);
                    ConsoleKeyInfo key = Console.ReadKey();
                    check_answer(key, ref (question_number), ref score);
                    question_number++;
                }
                if (score < 0) { score = 0; }

                Console.WriteLine($"Your score: {score}");
                Console.WriteLine("Press enter if you want to play again.");
                ConsoleKeyInfo key2 = Console.ReadKey();
                if (key2.Key == ConsoleKey.Enter)
                {
                    continue;
                }
                else
                {
                    choice = false;
                    Console.WriteLine("Okay, byee!");
                    Console.ReadKey();
                }
            }
        }
    }
}