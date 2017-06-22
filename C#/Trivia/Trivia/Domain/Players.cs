using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia.Domain
{
    public class Players
    {

        public Players(IQuestionUI questionUi)
        {
            ListePlayers = new List<Player>();
            CurrentPlayer = null;
            QuestionUi = questionUi;
        }

        public IQuestionUI QuestionUi { get; private set; }

        public Player CurrentPlayer { get; private set; }

        public List<Player> ListePlayers { get; private set; }

        public bool AddAPlayer(String playerName)
        {
            Player player = new Player(playerName, QuestionUi);
            if (!ListePlayers.Any())
            {
                CurrentPlayer = player;
            }
            ListePlayers.Add(player);
            //CurrentPlayer = player;
            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + NbPlayers());
            return true;
        }

        public int NbPlayers()
        {
            return ListePlayers.Count;
        }

        public void NextPlayer()
        {
            if (ListePlayers.IndexOf(CurrentPlayer) == NbPlayers()-1)
            {
                CurrentPlayer = ListePlayers[0];
            }
            else
            {
                CurrentPlayer = ListePlayers[ListePlayers.IndexOf(CurrentPlayer) + 1];
            }
        }

    }
}
