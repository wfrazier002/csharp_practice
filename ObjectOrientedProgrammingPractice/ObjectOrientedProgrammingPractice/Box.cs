using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingPractice {
    class Box {
        // challenge: create a private read only prop 'frontsurface' that calculates the front 
        // surface based on the height and length

        private double length, height, width, volume;

        public double FrontSurface 
        {
            get { return this.height * this.length; }
        }
        

        public double getVolume() {
            return volume;
        }

        public double getLength() {
            return length;
        }
        public double getHeight() {
            return height;
        }
        public double getWidth() {
            return width;
        }
        public void setLength(double length) {
            if (length < 0) {
                throw new Exception("you can't have a length of less than 0");
            } else {
                this.length = length;
            }
        }
        public void setHeight(double height) {
            if (height < 0) {
                throw new Exception("you can't have a height of less than 0");
            } else {
                this.height = height;
            }
        }
        public void setWidth(double width) {
            if (width < 0) {
                throw new Exception("you can't have a width of less than 0");
            } else {
                 this.width = width;
            }
        }

        public void DisplayInfo() {
            Console.WriteLine("the length is: {0}, the width is: {1}, and the height is: {2}", length, width, height);
            Console.WriteLine("the volume using those values is: {0}", CalculateVolume(length, width, height));
        }

        private double CalculateVolume(double length, double width, double height) {
            this.volume = length * width * height;
            return this.volume;
        }

        // a finalizer is a method that is run when an obj is deleted, closes, or runs out of scope
        // don't have an empty finalizer, only use if you have something you need to do here; otherwise it uses up extra performance.
        ~Box() {

            Console.WriteLine("deconstruction of object box has begun");
        }
    }
}
