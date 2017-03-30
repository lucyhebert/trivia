using System;

namespace Trivia
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int Place { get; set; }
        public int GoldCoins { get; set; }
        public bool IsInPenaltyBox { get; set; }

        public Player(String name)
        {
            PlayerName = name;
            Place = 0;
            GoldCoins = 0;
            IsInPenaltyBox = false;
        }


        private void Move(int roll)
        {
            Place = Place + roll;
        }

        public void WinAGoldCoin()
        {
            GoldCoins++;
            Console.WriteLine(PlayerName
                              + " now has "
                              + GoldCoins
                              + " Gold Coins.");
        }

    }
}