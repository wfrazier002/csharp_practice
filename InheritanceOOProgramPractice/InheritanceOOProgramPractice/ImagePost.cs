using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceOOProgramPractice {
    class ImagePost : Post {
        public string ImageURL { get; set; }
        public ImagePost(string title, bool isPublic, string sendByUsername, string imageURL) : base(title, isPublic, sendByUsername) {
            this.ImageURL = imageURL;
        }

        public ImagePost() { }

        public override string ToString() {
            if (!string.IsNullOrEmpty(ImageURL)) { 
                string aString = base.ToString();
                aString += string.Format(" image located: {0}", ImageURL);
                return aString;
            } else {
                return base.ToString();
            }

        }

    }
}
