using System;

namespace Trivia
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int Place { get; set; }
        public int Purse { get; set; }
        public bool InPenaltyBox { get; set; }

        public Player(String name)
        {
            PlayerName = name;
            Place = 0;
            Purse = 0;
            InPenaltyBox = false;
        }

    }
}