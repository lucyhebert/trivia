﻿namespace Trivia.Domain
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int Place { get; set; }
        public int GoldCoins { get; set; }
        public bool IsInPenaltyBox { get; set; }
        public IQuestionUI QuestionUi { get; set; }

        public Player(string name, IQuestionUI questionUi)
        {
            PlayerName = name;
            Place = 0;
            GoldCoins = 0;
            IsInPenaltyBox = false;
            QuestionUi = questionUi;
        }


        public void Move(int roll)
        {
            Place = Place + roll;
            if (Place > 11) Place = Place - 12;
        }

        public void WinAGoldCoin()
        {
            GoldCoins++;
            QuestionUi.Display(PlayerName
                              + " now has "
                              + GoldCoins
                              + " Gold Coins.");
        }

        public void GoToPenaltyBox()
        {
            IsInPenaltyBox = true;
        }

        //public void GoOutFromPenaltyBox()
        //{
        //    IsInPenaltyBox = false;
        //}

        public bool IsWinner()
        {
            return GoldCoins == 6;
        }
    }
}