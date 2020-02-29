using System;

namespace Ch09Ex03
{
    class Myclass
    {
        public int val;
    }
    struct myStruct
    {
        public int val;
    }
        class Program
    {
        static void Main(string[] args)
        {
            Myclass objectA = new Myclass();
            Myclass objectB = objectA;
            objectA.val = 10;
            objectB.val = 20;
            myStruct structA = new myStruct();
            myStruct structB = structA;
            structA.val = 30;
            structB.val = 40;

            Console.WriteLine("objectA.val = {0}", objectA.val);
            Console.WriteLine("objectA.val = {0}", objectB.val);
            Console.WriteLine("structA.val = {0}", structA.val);
            Console.WriteLine("structB.val = {0}", structB.val);
            Console.ReadKey();                          
        }
    }
}
