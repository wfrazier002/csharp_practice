using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace InheritanceOOProgramPractice {
    class VideoPost : Post {
        public string VideoURL { get; set; }
        public double Length { get; set; }
        private static Timer aTimer;
        private bool isPlaying = false;
        private int currentDuration = 0;
        //private double timerLength = 0;
        //private Stopwatch stopWatch = new Stopwatch();


        public VideoPost() {

        }

        public VideoPost(string title, bool isPublic, string sendByUsername, string videoURL, double length) : base(title, isPublic, sendByUsername) {
            this.VideoURL = videoURL;
            this.Length = length;
            // to get it to work w/ length, you would have to do a few things. you'd have to implement timer (instead of stopwatch or along w/ stopwatch)
            // then you have to change play and stop to use the length - only allow play to work if the video isn't playing already
            // also only allow stop to stop if the video is playing or if the timer hits length.
            // also have to implement a counter to increment along w/ the callback method (the callback method should be called every 1000 ms or 1 s

            /*Play();
            Console.ReadLine();
            Stop(); */
        }

        public override string ToString() {
            if (!string.IsNullOrEmpty(VideoURL)) {
                string aString = base.ToString();
                aString += string.Format(" video located: {0}, and it has a length of {1}", VideoURL, Length);             
                return aString;
            } else {
                return base.ToString();
            }
            
        }
        
        /*public void Play() {
            stopWatch.Start();
            Console.WriteLine("\nPress any key to stop the video...\n");
            Console.WriteLine("The video started at {0:HH:mm:ss.fff}", DateTime.Now);
        }
        public void Stop() {
            stopWatch.Stop();
            timerLength = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("stopped at {0} secs", timerLength/1000);
        } */
        // if you implemented timer instead of stopwatch:
        public void Play() {
            if (!isPlaying) {
                Console.WriteLine("video is playing");
                isPlaying = true;
                // timercallback - method we'll make; null; time it starts - 0; timer increments 1000 = 1s
                aTimer = new Timer(TimerCallBack, null, 0, 1000);
            }
        }

        private void TimerCallBack(Object obj) {
            if (currentDuration < Length) {
                currentDuration++;
                Console.WriteLine("video is currently at {0} secs", currentDuration);
                // need to garbage collect here
                GC.Collect();
            } else {
                Stop();
            }
        }

        public void Stop() {
            if (isPlaying) {
                isPlaying = false;
                Console.WriteLine("stopped video at {0} sec", currentDuration);
                currentDuration = 0;
                aTimer.Dispose();
            }
        }
         
    }
}
