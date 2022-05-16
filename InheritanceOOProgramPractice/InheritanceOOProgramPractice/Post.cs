using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class Post {
        private static int currentPostId;

        //protected means it can only be used by that class and any class that inherts from that class
        protected int ID { get; set; }

        protected string Title { get; set; }
        protected string SendByUsername { get; set; }
        protected bool IsPublic { get; set; }

        // this will be the default constructor, that way if a class doesn't change anything it will 
        // have default settings
        public Post() {
            ID = 0;
            Title = "My default first Post";
            IsPublic = true;
            SendByUsername = "Dark Bahamut";
        }

        // can make multiple constructors as well, that way the derived classes can use one of them
        public Post(string title, bool isPublic, string sendByUsername) {
            this.SendByUsername = sendByUsername;
            this.Title = title;
            this.IsPublic = isPublic;
            // don't want this, make a method to get a new id
            //this.ID = 0;
            this.ID = GetNextID();
        }

        // don't want all ids to be 0, so create a protected method to find the next usable id
        protected int GetNextID() {
            // increment the current id and pass that new num to the next post
            return ++currentPostId;
        }

        // create way to edit post
        public void Update(string title, bool isPublic) {
            this.Title = title;
            this.IsPublic = isPublic;
        }

        // for this class, override system.object.tostring method to show inheritance and how it can be overridden
        public override string ToString() {
            return string.Format("{0} - {1} - by {2}", ID, Title, SendByUsername);
        }
    }
}
