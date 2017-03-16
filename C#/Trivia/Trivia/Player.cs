using System;

namespace Trivia
{
    public class Player
    {
        public String PlayerName { get; set; }
        public int Place { get; set; }
        public int Purse { get; set; }
        public bool InPenaltyBox { get; set; }

        public Player(String name)
        {
            this.PlayerName = name;
            this.Place = 0;
            this.Purse = 0;
            this.InPenaltyBox = false;
        }

    }
}