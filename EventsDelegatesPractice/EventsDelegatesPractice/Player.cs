using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesPractice {
    class Player {

        public string PlayerName { get; set; }

        public Player(string name) {
            this.PlayerName = name;
            // challenge: create a constructor that will add the below methods to the gameeventmanager
            GameEventManager.onGameStart += StartGame;
            GameEventManager.onGameEnd += EndGame;
        }

        private void StartGame() {
            Console.WriteLine("Spawning player w/ ID: {0}", PlayerName);
        }
        private void EndGame() {
            Console.WriteLine("Removing player w/ ID: {0}", PlayerName);
        }
    }
}
