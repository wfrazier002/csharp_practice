using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesPractice {
    class AudioSystem {

        // add in a constructor, then add the start/end methods to the class that is calling it
        public AudioSystem() {
            GameEventManager.onGameStart += StartGame;
            GameEventManager.onGameEnd += EndGame;
        }

        private void StartGame() {
            Console.WriteLine("Audio System Started...");
            Console.WriteLine("Loading Audio...");
        }

        private void EndGame() {
            Console.WriteLine("Rendering Audio System Stop...");
        }
    }
}
