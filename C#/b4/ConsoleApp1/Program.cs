using System;

namespace ConsoleApp1
{
    public abstract class Shape
    {
        private string myID;
        public Shape(string s)
        {
            ID = s;
        }
        public string ID
        {
            get
            {
                return myID;
            }
            set
            {
                myID = value;
            }
        }
        public abstract double Area
        {
            get;
        }

        public abstract string judging();
        public override string ToString()
        {
            return ID + " Area =  " + Area + "  "+judging();
        }
    }

    public class Rectangle : Shape
    {
        private double myLength;
        private double myWidth;
        public Rectangle(double length, double width, string ID) : base(ID)
        {
            myLength = length;
            myWidth = width;
        }

        public override double Area
        {
            get
            {
                return myLength * myWidth;
            }
        }
        public override string judging()
        {
            if (myLength > 0 && myWidth > 0) return "符合矩形要求";
            else return "错误！不是一个矩形！";
        }

    }

    public class Traingle : Shape
    {
        private double mySide1;
        private double mySide2;
        private double mySide3;
        public Traingle(double s1, double s2,double s3, string ID) : base(ID)
        {
            mySide1 = s1;
            mySide2 = s2;
            mySide3 = s3;
        }
    public override double Area
        {
            get
            {
                double p = (mySide1 + mySide2 + mySide3)/2;
                return System.Math.Sqrt(p * (p - mySide1) * (p - mySide2) * (p - mySide3)) ;
            }
        }
        public override string judging()
        {
            if (mySide1 > 0 && mySide2 > 0 && mySide3>0 && mySide1+mySide2 > mySide3) return "符合三角形要求";
            else return "错误！不是一个三角形！";
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Shape[] shapes = { new Traingle(3, 4, 5, "Traingle #1"), new Rectangle(2, 3, "Rectangle #1") };
            foreach(Shape s in shapes)
            {
                Console.WriteLine(s);
                
            }
        }
    }
}
