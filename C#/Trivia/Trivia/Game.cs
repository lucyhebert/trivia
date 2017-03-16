using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        readonly List<Player> _players = new List<Player>();

        readonly List<string> _categories = new List<string>();

        readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        int _currentPlayer;
        bool _isGettingOutOfPenaltyBox;

        public Game()
        {
            _categories.Add("Pop");
            _categories.Add("Science");
            _categories.Add("Sports");
            for (int i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast(CreateRockQuestion(i));
            }
        }

        public string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool IsPlayable()
        {
            return (HowManyPlayers() >= 2);
        }

        public bool Add(string playerName)
        {


            _players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public int HowManyPlayers()
        {
            return _players.Count;
        }

        public Player CurrentPlayer()
        {
            return _players[_currentPlayer];
        }

        public void Roll(int roll)
        {
            Console.WriteLine(CurrentPlayer().PlayerName + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (CurrentPlayer().InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(CurrentPlayer().PlayerName + " is getting out of the penalty box");
                    CurrentPlayer().Place = CurrentPlayer().Place + roll;
                    if (CurrentPlayer().Place > 11) CurrentPlayer().Place = CurrentPlayer().Place - 12;

                    Console.WriteLine(CurrentPlayer().PlayerName
                            + "'s new location is "
                            + CurrentPlayer().Place);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(CurrentPlayer().PlayerName + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {

                CurrentPlayer().Place = CurrentPlayer().Place + roll;
                if (CurrentPlayer().Place > 11) CurrentPlayer().Place = CurrentPlayer().Place - 12;

                Console.WriteLine(CurrentPlayer().PlayerName
                        + "'s new location is "
                        + CurrentPlayer().Place);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }

        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Rock")
            {
                Console.WriteLine(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }

        private string CurrentCategory()
        {
            if (CurrentPlayer().Place == 0) return "Pop";
            if (CurrentPlayer().Place == 4) return "Pop";
            if (CurrentPlayer().Place == 8) return "Pop";
            if (CurrentPlayer().Place == 1) return "Science";
            if (CurrentPlayer().Place == 5) return "Science";
            if (CurrentPlayer().Place == 9) return "Science";
            if (CurrentPlayer().Place == 2) return "Sports";
            if (CurrentPlayer().Place == 6) return "Sports";
            if (CurrentPlayer().Place == 10) return "Sports";
            return "Rock";
        }

        public bool WasCorrectlyAnswered()
        {
            if (CurrentPlayer().InPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    CurrentPlayer().Purse++;
                    Console.WriteLine(CurrentPlayer().PlayerName
                            + " now has "
                            + CurrentPlayer().Purse
                            + " Gold Coins.");

                    bool winner = DidPlayerWin();
                    _currentPlayer++;
                    if (_currentPlayer == _players.Count) _currentPlayer = 0;

                    return winner;
                }
                else
                {
                    _currentPlayer++;
                    if (_currentPlayer == _players.Count) _currentPlayer = 0;
                    return true;
                }



            }
            else
            {

                Console.WriteLine("Answer was corrent!!!!");
                CurrentPlayer().Purse++;
                Console.WriteLine(CurrentPlayer().PlayerName
                        + " now has "
                        + CurrentPlayer().Purse
                        + " Gold Coins.");

                bool winner = DidPlayerWin();
                _currentPlayer++;
                if (_currentPlayer == _players.Count) _currentPlayer = 0;

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(CurrentPlayer().PlayerName + " was sent to the penalty box");
            CurrentPlayer().InPenaltyBox = true;

            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin()
        {
            return CurrentPlayer().Purse != 6;
        }
    }

}
