using System;

namespace ex03
{
    enum orientation : byte

   {
        north = 1,
        south = 2,
        east = 3,
        west =  4,
    }
    struct route
    {
        public orientation direction;
        public double distance;
    }
    class Program
    {
        static void Main(string[] args)
        {
            route myroute;
            int myDirection = -1;
            double mydistance;
            Console.WriteLine("1) North\n2) South\n3) East\n4) West");
            do
            {
                Console.WriteLine("Select a direction");
                myDirection = Convert.ToInt32(Console.ReadLine());
            }
            while ((myDirection < 1) || (myDirection > 4));
            Console.WriteLine("Input a Distance");
            mydistance = Convert.ToDouble(Console.ReadLine());
            myroute.direction = (orientation)myDirection;
            myroute.distance = mydistance;
            Console.WriteLine("myRoute specification a direction of {0} and a " + " distance of {1}", myroute.direction, myroute.distance);
            Console.ReadKey();
        }
    }
}
