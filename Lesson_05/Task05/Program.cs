using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    /// <summary>
    /// 5. **Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет. 
    /// Например: «Шариковую ручку изобрели в древнем Египте», «Да». 
    /// Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку. 
    /// Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ. 
    /// Список вопросов ищите во вложении или воспользуйтесь интернетом.
    /// </summary>
    class Program
    {
        class Game
        {
            int count;
            string[,] quiz;

            #region Constructors
            public Game(string path)
            {
                int n = 0;
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        n++;
                }

                count = n / 2;
                quiz = new string[count, 2];

                using (StreamReader sr = new StreamReader(path))
                {
                    for (int i = 0; i < count; i++)
                    {
                        quiz[i,0] = sr.ReadLine();
                        quiz[i, 1] = sr.ReadLine();
                    }
                }
            }
            #endregion

            #region Public Methods

            public void Run(int num)
            {
                if (num > count)
                    throw new Exception("Мало вопросов в наличии");

                var gameQuiz = new int[count];
                int right = 0;
                gameQuiz = Enumerable.Range(0, count).OrderBy(c => Guid.NewGuid()).ToArray();

                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine($"Вопрос №{i + 1}:");
                    Console.WriteLine(quiz[gameQuiz[i], 0]);
                    var ans = Console.ReadLine();
                    if (ans == quiz[gameQuiz[i], 1])
                        right++;
                }
                Console.WriteLine($"Количество правильных ответов: {right}");
            }
            #endregion

        }
        static void Main(string[] args)
        {
            var newGame = new Game(AppDomain.CurrentDomain.BaseDirectory + "Game.txt");

            newGame.Run(3);

            Console.ReadKey();
        }
    }
}
