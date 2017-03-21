using System;
using System.Collections;
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
            PopulateCategories();
            AddQuestions();
        }

        private void PopulateCategories()
        {
            _categories.Add("Pop");
            _categories.Add("Science");
            _categories.Add("Sports");
            _categories.Add("Rock");
        }

        public void AddQuestions()
        {
            for (int i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast("Science Question " + i);
                _sportsQuestions.AddLast("Sports Question " + i);
                _rockQuestions.AddLast("Rock Question " + i);
            }
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
                    Console.WriteLine("The category is " + CurrentCategory(CurrentPlayer().Place));
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
                Console.WriteLine("The category is " + CurrentCategory(CurrentPlayer().Place));
                AskQuestion();
            }
        }

        private void AskQuestion()
        {
            if (CurrentCategory(CurrentPlayer().Place) == "Pop")
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CurrentCategory(CurrentPlayer().Place) == "Science")
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory(CurrentPlayer().Place) == "Sports")
            {
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory(CurrentPlayer().Place) == "Rock")
            {
                Console.WriteLine(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }

        private string CurrentCategory(int index)
        {
            string currentCategory = "";
            for (int i = 0; i < _categories.Count; i++)
            {
                if (index % 4 == i) currentCategory = _categories[i];
            }
            return currentCategory;
        }

        public bool WasCorrectlyAnswered()
        {
            if (CurrentPlayer().InPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    return Wins();
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
                return Wins();
            }
        }

        private bool Wins()
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
