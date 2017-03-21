using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        readonly List<Player> _players = new List<Player>();

        readonly List<Category> _categories = new List<Category>();

        private readonly Category _popCategory = new Category("Pop");
        private readonly Category _scienceCategory = new Category("Science");
        private readonly Category _sportsCategory = new Category("Sports");
        private readonly Category _rockCategory = new Category("Rock");

        int _currentPlayer;
        bool _isGettingOutOfPenaltyBox;

        public Game()
        {
            PopulateCategories();
        }

        private void PopulateCategories()
        {
            _categories.Add(_popCategory);
            _categories.Add(_scienceCategory);
            _categories.Add(_sportsCategory);
            _categories.Add(_rockCategory);
        }

        public bool AddPlayer(string playerName)
        {
            _players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public bool IsPlayable()
        {
            return (_players.Count >= 2);
        }

        public Player CurrentPlayer()
        {
            return _players[_currentPlayer];
        }

        public void Roll(int roll)
        {
            Console.WriteLine(CurrentPlayer().PlayerName + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (CurrentPlayer().InPenaltyBox || roll % 2 != 0)
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

        private void AskQuestion()
        {
            if (CurrentCategory(CurrentPlayer().Place) == "Pop")
            {
                Console.WriteLine(_popCategory.QuestionList.First());
                _popCategory.QuestionList.RemoveFirst();
            }
            if (CurrentCategory(CurrentPlayer().Place) == "Science")
            {
                Console.WriteLine(_scienceCategory.QuestionList.First());
                _scienceCategory.QuestionList.RemoveFirst();
            }
            if (CurrentCategory(CurrentPlayer().Place) == "Sports")
            {
                Console.WriteLine(_sportsCategory.QuestionList.First());
                _sportsCategory.QuestionList.RemoveFirst();
            }
            if (CurrentCategory(CurrentPlayer().Place) == "Rock")
            {
                Console.WriteLine(_rockCategory.QuestionList.First());
                _rockCategory.QuestionList.RemoveFirst();
            }
        }

        private string CurrentCategory(int index)
        {
            string currentCategory = "";
            for (int i = 0; i < _categories.Count; i++)
            {
                if (index % 4 == i) currentCategory = _categories[i].CategoryName;
            }
            return currentCategory;
        }

        public bool WasCorrectlyAnswered()
        {
            if (CurrentPlayer().InPenaltyBox || _isGettingOutOfPenaltyBox)
            {
                Console.WriteLine("Answer was correct!!!!");
                CurrentPlayer().Purse++;
                Console.WriteLine(CurrentPlayer().PlayerName
                        + " now has "
                        + CurrentPlayer().Purse
                        + " Gold Coins.");

                NextPlayer();
                return DidPlayerWin();
            }
            else
            {
                NextPlayer();
                return true;
            }
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(CurrentPlayer().PlayerName + " was sent to the penalty box");
            CurrentPlayer().InPenaltyBox = true;

            NextPlayer();
            return true;
        }

        private bool DidPlayerWin()
        {
            return CurrentPlayer().Purse != 6;
        }

        private void NextPlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }
    }

}
