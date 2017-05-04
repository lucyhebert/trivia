using System;

namespace Trivia
{
    public class Game
    {
        private readonly Players _players;
        private readonly Questions _questions;
        private readonly IQuestionsRepository _repository;

        public bool GoOutFromPenaltyBox;

        public Game(Players players, Questions questions, IQuestionsRepository repository)
        {
            _players = players;
            _questions = questions;
            _repository = repository;

        }

        public void Roll(int roll)
        {
            string[] question = null;
            Console.WriteLine(_players.CurrentPlayer.PlayerName + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_players.CurrentPlayer.IsInPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    GoOutFromPenaltyBox = true;
                    Console.WriteLine(_players.CurrentPlayer.PlayerName + " is getting out of the penalty box");
                    _players.CurrentPlayer.Move(roll);

                    Console.WriteLine(_players.CurrentPlayer.PlayerName
                                  + "'s new location is "
                                  + _players.CurrentPlayer.Place);
                    question = _questions.AskQuestion(_players.CurrentPlayer.Place);
                    Console.WriteLine("The category is " + question[0]);
                    Console.WriteLine(question[1]);
                }
                else
                {
                    GoOutFromPenaltyBox = false;
                    Console.WriteLine(_players.CurrentPlayer.PlayerName + " is not getting out of the penalty box");
                }
            }
            else
            {
                _players.CurrentPlayer.Move(roll);
                Console.WriteLine(_players.CurrentPlayer.PlayerName
                                  + "'s new location is "
                                  + _players.CurrentPlayer.Place);
                question = _questions.AskQuestion(_players.CurrentPlayer.Place);
                Console.WriteLine("The category is " + question[0]);
                Console.WriteLine(question[1]);
            }
        }

        public bool WasCorrectlyAnswered()
        {
            //if (_players.CurrentPlayer.IsInPenaltyBox)
            //{
            //    Console.WriteLine("Answer was correct!!!!");
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
                    Console.WriteLine("Answer was correct!!!!");
                    _players.CurrentPlayer.WinAGoldCoin();

                    winner = _players.CurrentPlayer.IsWinner();
                    _players.NextPlayer();

                    return winner;
                }

                _players.NextPlayer();
                return false;

            }

            Console.WriteLine("Answer was corrent!!!!");
            _players.CurrentPlayer.WinAGoldCoin();

            winner = _players.CurrentPlayer.IsWinner();
            _players.NextPlayer();

            return winner;

        }


        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players.CurrentPlayer.PlayerName + " was sent to the penalty box");
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
