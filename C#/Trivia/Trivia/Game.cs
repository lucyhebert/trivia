using System;

namespace Trivia
{
    public class Game
    {
        private readonly Players _players;
        private readonly Questions _questions;

        public Game(Players players, Questions questions)
        {
            _players = players;
            _questions = questions;
            
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players.CurrentPlayer.PlayerName + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_players.CurrentPlayer.IsInPenaltyBox || roll % 2 != 0)
            {
                _players.CurrentPlayer.GoOutFromPenaltyBox();
                Console.WriteLine(_players.CurrentPlayer.PlayerName + " is getting out of the penalty box");
                _players.CurrentPlayer.Move(roll);

                Console.WriteLine(_players.CurrentPlayer.PlayerName
                        + "'s new location is "
                        + _players.CurrentPlayer.Place);
                string[] question = _questions.AskQuestion(_players.CurrentPlayer.Place);
                Console.WriteLine("The category is " + question[0]);
                Console.WriteLine(question[1]);
            }
            else
            {
                Console.WriteLine(_players.CurrentPlayer.PlayerName + " is not getting out of the penalty box");
                _players.CurrentPlayer.GoToPenaltyBox();
            }
        }

        public bool WasCorrectlyAnswered()
        {
            if (_players.CurrentPlayer.IsInPenaltyBox)
            {
                Console.WriteLine("Answer was correct!!!!");
                _players.CurrentPlayer.WinAGoldCoin();
                _players.NextPlayer();
                return DidPlayerWin();
            }
            else
            {
                _players.NextPlayer();
                return true;
            }
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players.CurrentPlayer.PlayerName + " was sent to the penalty box");
            _players.CurrentPlayer.IsInPenaltyBox = true;

            _players.NextPlayer();
            return true;
        }

        private bool DidPlayerWin()
        {
            return _players.CurrentPlayer.GoldCoins != 6;
        }
    }

}
