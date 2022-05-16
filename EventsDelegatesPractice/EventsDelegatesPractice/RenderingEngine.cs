using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesPractice {
    class RenderingEngine {

        // challenge: create a constructor that will add the below methods to the gameeventmanager
        public RenderingEngine() {
            GameEventManager.onGameStart += StartGame;
            GameEventManager.onGameEnd += EndGame;
        }

        private void StartGame() {
            Console.WriteLine("Rendering Engine Start...");
            Console.WriteLine("Creating Visuals...");
        }

        private void EndGame() {
            Console.WriteLine("Rendering Enginge Stop...");
        }
    }
}
