using System;

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
                Game aGame = new Game();

                aGame.Add("Chet");
                aGame.Add("Pat");
                aGame.Add("Sue");

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

