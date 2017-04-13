using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly Players _players;

        private readonly Questions _questions;

        public Game(Players players)
        {
            _players = players;
            _questions = new Questions();
            
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
                Console.WriteLine("The category is " + _questions.CurrentCategory(_players.CurrentPlayer.Place));
                AskQuestion();
            }
            else
            {
                Console.WriteLine(_players.CurrentPlayer.PlayerName + " is not getting out of the penalty box");
                _players.CurrentPlayer.GoToPenaltyBox();
            }
        }

        private void AskQuestion()
        {
            Console.WriteLine(_questions.CurrentCategory(_players.CurrentPlayer.Place).QuestionList.First());
            _questions.CurrentCategory(_players.CurrentPlayer.Place).QuestionList.RemoveFirst();
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
