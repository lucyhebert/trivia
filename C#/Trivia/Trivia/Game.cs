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

        //public bool IsPlayable()
        //{
        //    return (_players.Count >= 2);
        //}

        public Player CurrentPlayer()
        {
            return _players[_currentPlayer];
        }

        public void Roll(int roll)
        {
            Console.WriteLine(CurrentPlayer().PlayerName + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (CurrentPlayer().IsInPenaltyBox || roll % 2 != 0)
            {
                _isGettingOutOfPenaltyBox = true;
                Console.WriteLine(CurrentPlayer().PlayerName + " is getting out of the penalty box");
                Move(roll);
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

        private void Move(int roll)
        {
            CurrentPlayer().Place = CurrentPlayer().Place + roll;
        }

        private void AskQuestion()
        {
            Console.WriteLine(CurrentCategory(CurrentPlayer().Place).QuestionList.First());
            CurrentCategory(CurrentPlayer().Place).QuestionList.RemoveFirst();
        }

        private Category CurrentCategory(int index)
        {
            Category currentCategory = null;
            for (int i = 0; i < _categories.Count; i++)
            {
                if (index % 4 == i) currentCategory = _categories[i];
            }
            return currentCategory;
        }

        public bool WasCorrectlyAnswered()
        {
            if (CurrentPlayer().IsInPenaltyBox || _isGettingOutOfPenaltyBox)
            {
                Console.WriteLine("Answer was correct!!!!");
                WinAGoldCoin();
                NextPlayer();
                return DidPlayerWin();
            }
            else
            {
                NextPlayer();
                return true;
            }
        }

        private void WinAGoldCoin()
        {
            CurrentPlayer().GoldCoins++;
            Console.WriteLine(CurrentPlayer().PlayerName
                              + " now has "
                              + CurrentPlayer().GoldCoins
                              + " Gold Coins.");
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(CurrentPlayer().PlayerName + " was sent to the penalty box");
            CurrentPlayer().IsInPenaltyBox = true;

            NextPlayer();
            return true;
        }

        private bool DidPlayerWin()
        {
            return CurrentPlayer().GoldCoins != 6;
        }

        private void NextPlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }
    }

}
