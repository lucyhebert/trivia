﻿using System;
using System.Collections.Generic;

namespace Trivia
{
    public class Players
    {
        public Players()
        {
            ListePlayers = new List<Player>();
            CurrentPlayer = null;
        }

        public Player CurrentPlayer { get; private set; }

        public List<Player> ListePlayers { get; private set; }

        public bool AddAPlayer(String playerName)
        {
            Player player = new Player(playerName);
            ListePlayers.Add(player);
            CurrentPlayer = player;
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