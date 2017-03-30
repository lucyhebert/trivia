using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        //readonly List<Player> _players = new List<Player>();

        private readonly Players _players;

        readonly List<Category> _categories = new List<Category>();

        private readonly Category _popCategory = new Category("Pop");
        private readonly Category _scienceCategory = new Category("Science");
        private readonly Category _sportsCategory = new Category("Sports");
        private readonly Category _rockCategory = new Category("Rock");

        int _currentPlayer;

        public Game(Players players)
        {
            _players = players;
            _categories.Add(_popCategory);
            _categories.Add(_scienceCategory);
            _categories.Add(_sportsCategory);
            _categories.Add(_rockCategory);
        }

        //public bool AddPlayer(string playerName)
        //{
        //    _players.AddAPlayer(new Player(playerName));

        //    Console.WriteLine(playerName + " was added");
        //    Console.WriteLine("They are player number " + _players.NbPlayers());
        //    return true;
        //}

        //public bool IsPlayable()
        //{
        //    return (_players.Count >= 2);
        //}

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
                Console.WriteLine("The category is " + CurrentCategory(_players.CurrentPlayer.Place));
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
            Console.WriteLine(CurrentCategory(_players.CurrentPlayer.Place).QuestionList.First());
            CurrentCategory(_players.CurrentPlayer.Place).QuestionList.RemoveFirst();
        }

        private Category CurrentCategory(int index)
        {
            var currentCategory = _categories[index % 4];
            return currentCategory;
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

        //private void NextPlayer()
        //{
        //    _currentPlayer++;
        //    if (_currentPlayer == _players.NbPlayers()) _currentPlayer = 0;
        //}
    }

}
