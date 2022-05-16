using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesPractice {
    class GameEventManager {

        public delegate void GameEvent();

        // these will contain each game event from other classes that call this one
        public static event GameEvent onGameStart, onGameEnd;

        // create 2 public static methods that will trigger every other event
        public static void TriggerGameStart() {
            // check if the onGameStart is empty
            // if not, other methods already added to it
            if (onGameStart != null) {
                Console.WriteLine("the game is starting...");
                onGameStart();
            }
        }

        public static void TriggerGameEnd() {
            // check if the onGameStart is empty
            // if not, other methods already added to it
            if (onGameEnd != null) {
                Console.WriteLine("the game is ending...");
                onGameEnd();
            }
        }
    }
}
