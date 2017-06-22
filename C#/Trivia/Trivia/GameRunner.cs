using System;
using System.Collections.Generic;

namespace Trivia
{
    public class GameRunner
    {
        private static bool _isAWinner;

        public static void Main(string[] args)
        {
            int i;
            for (i = 0; i < 10; i++)
            {
                var repository = new QuestionsFileRepository();
                var questionUi = new ConsoleUI();

                Players players = new Players(questionUi);
                Questions questions = null;

                players.AddAPlayer("Chet");
                players.AddAPlayer("Pat");
                players.AddAPlayer("Sue");

                List<String> categories = new List<string>();

                questions = new Questions(categories, repository);
                

                Game aGame = new Game(players, questions, questionUi);


                Random rand = new Random(i);

                do
                {
                    aGame.Roll(rand.Next(5) + 1);

                    if (rand.Next(9) == 7)
                    {
                        _isAWinner = aGame.WrongAnswer();
                    }
                    else
                    {
                        _isAWinner = aGame.WasCorrectlyAnswered();
                    }
                } while (!_isAWinner);
            }
        }
    }
}

