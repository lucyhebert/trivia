using System;

namespace Trivia
{
    public class Game
    {
        private readonly Players _players;
        private readonly Questions _questions;
        private readonly IQuestionUI _questionUi;

        public bool GoOutFromPenaltyBox;

        public Game(Players players, Questions questions, IQuestionUI questionUi) {
            _players = players;
            _questions = questions;
            _questionUi = questionUi;
        }

        public void Roll(int roll)
        {
            string[] question = null;
            _questionUi.Display(_players.CurrentPlayer.PlayerName + " is the current player");
            _questionUi.Display("They have rolled a " + roll);

            if (_players.CurrentPlayer.IsInPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    GoOutFromPenaltyBox = true;
                    _questionUi.Display(_players.CurrentPlayer.PlayerName + " is getting out of the penalty box");
                    _players.CurrentPlayer.Move(roll);

                    _questionUi.Display(_players.CurrentPlayer.PlayerName
                                  + "'s new location is "
                                  + _players.CurrentPlayer.Place);
                    question = _questions.AskQuestion(_players.CurrentPlayer.Place);
                    _questionUi.Display("The category is " + question[0]);
                    _questionUi.Display(question[1]);
                }
                else
                {
                    GoOutFromPenaltyBox = false;
                    _questionUi.Display(_players.CurrentPlayer.PlayerName + " is not getting out of the penalty box");
                }
            }
            else
            {
                _players.CurrentPlayer.Move(roll);
                _questionUi.Display(_players.CurrentPlayer.PlayerName
                                  + "'s new location is "
                                  + _players.CurrentPlayer.Place);
                question = _questions.AskQuestion(_players.CurrentPlayer.Place);
                _questionUi.Display("The category is " + question[0]);
                _questionUi.Display(question[1]);
            }
        }

        public bool WasCorrectlyAnswered()
        {
            //if (_players.CurrentPlayer.IsInPenaltyBox)
            //{
            //    _questionUi.Display("Answer was correct!!!!");
            //    _players.CurrentPlayer.WinAGoldCoin();
            //    _players.NextPlayer();
            //    return DidPlayerWin();
            //}
            //else
            //{
            //    _players.NextPlayer();
            //    return true;
            //}

            bool winner;

            if (_players.CurrentPlayer.IsInPenaltyBox)
            {
                if (GoOutFromPenaltyBox)
                {
                    _questionUi.Display("Answer was correct!!!!");
                    _players.CurrentPlayer.WinAGoldCoin();

                    winner = _players.CurrentPlayer.IsWinner();
                    _players.NextPlayer();

                    return winner;
                }

                _players.NextPlayer();
                return false;

            }

            _questionUi.Display("Answer was corrent!!!!");
            _players.CurrentPlayer.WinAGoldCoin();

            winner = _players.CurrentPlayer.IsWinner();
            _players.NextPlayer();

            return winner;

        }


        public bool WrongAnswer()
        {
            _questionUi.Display("Question was incorrectly answered");
            _questionUi.Display(_players.CurrentPlayer.PlayerName + " was sent to the penalty box");
            _players.CurrentPlayer.GoToPenaltyBox();

            _players.NextPlayer();
            return false;
        }

        private bool DidPlayerWin()
        {
            return _players.CurrentPlayer.GoldCoins != 6;
        }
    }

}
