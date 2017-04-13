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
                Players players = new Players();
                Questions questions = null;

                players.AddAPlayer("Chet");
                players.AddAPlayer("Pat");
                players.AddAPlayer("Sue");

                List<String> categories = new List<string>();
                //categories.Add("Rock");
                //categories.Add("Sports");
                //categories.Add("Sciences");
                //categories.Add("Pop");
                //categories.Add("Histoire");

                if (categories.Count == 0)
                {
                    questions = new Questions();
                }
                else
                {
                    questions = new Questions(categories);
                }
                

                Game aGame = new Game(players, questions);


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
                } while (_isAWinner);
            }
        }
    }
}

