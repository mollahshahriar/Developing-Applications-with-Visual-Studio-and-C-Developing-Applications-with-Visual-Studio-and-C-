using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06Ex03
{
    class Program
    {
        static int sumVals(params int[] vals)
        {
            int sum = 0;
            foreach (int val in vals)
            {
                sum += val;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int sum = sumVals(1, 5, 2, 9, 8);
            Console.WriteLine("Summed Values = {0}", sum);
            Console.ReadKey();
        }
    }
}
