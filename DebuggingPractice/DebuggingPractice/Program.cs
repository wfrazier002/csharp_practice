using System;
using System.Collections.Generic;
using System.Linq;

namespace DebuggingPractice {
    class Program {
        static void Main(string[] args) {
            // example to show debugging for
            // first thing for debugging, you can add a breakpoint at line 10 to step into the funcs and see what happens to try to find the bug
            var friends = new List<string> { "frank", "joe", "michelle", "maria", "carlos", "angelina"};
            var partyFriends = GetPartyFriends(friends, -10);

            foreach (var name in partyFriends) {
                Console.WriteLine(name);
            }

            // autos and locals
            // friends (string list) is a local var only available in the main method
            // autos is a window that displays the variables on the current or preceding line

            // defensive programing = make secure code that already thinks about what problems can come up before release
        }

        private static List<string> GetPartyFriends(List<string> friends, int limit) {
            var partyFriends = new List<string>();
            // another thing found in debugging is that the person who made this program is removing items from the original list, rather than a copy of the list, which can cause some problems
            // another problem is to check if the list is null or empty before trying to copy it/work in it
            if (friends.Any() || friends.Count == 0) {
                throw new ArgumentNullException("friends", "the list of friends can't be empty or null.");
            }
            /*while (partyFriends.Count < limit) {
                var currentFriend = GetPartyFriend(friends);
                partyFriends.Add(currentFriend);
                friends.Remove(currentFriend);
            }*/
            // so, create a list for storing a copy of the original, and work off that one
            var copyFriendsList = new List<string>(friends);
            // another problem is that what if the limit is bigger than the list size? that will also cause errors, so you might want to think about comparing the limit and list sizes
            // so, another check is if the limit is bigger than the list size, adn if so what to do?
            // also, what if the limit is negative?
            if (limit > copyFriendsList.Count || limit <= 0) {
                // in this case, throw an exception for both
                throw new ArgumentOutOfRangeException("limit", "the limit/count of people to get from the list can't be bigger than the total size of the list of ppl to choose from or a negative number.");
            } else {
                while (partyFriends.Count < limit) {
                    var currentFriend = GetPartyFriend(copyFriendsList);
                    partyFriends.Add(currentFriend);
                    copyFriendsList.Remove(currentFriend);
                }
            }
            

            return partyFriends;
        }

        private static string GetPartyFriend(List<string> friends) {
            string shortestName = friends[0];

            foreach (string friend in friends) {
                // right way
                //if (friend.Length < shortestName.Length) {
                // incorrect way for debugging
                if (friend.Length > shortestName.Length) {
                    shortestName = friend;
                }
            }
            return shortestName;
        }
    }
}
