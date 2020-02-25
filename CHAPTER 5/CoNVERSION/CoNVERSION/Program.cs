using System;

namespace CoNVERSION

{ class Program
    {

        static void Main(string[] args)

        {
            try {
                short shortResult, shortVal = 4;
                int integerVal = 67;
                long longResult;
                float floatval = 10.5F;
                double doubleResult, doubleVal = 99.999;
                string stringResult, stringval = "17";
                bool boolVal = true;
                Console.WriteLine("Veriable Conversion Example\n");

                doubleResult = floatval * shortVal;
                Console.WriteLine("Implicit, -> double: {0} * {1} -> {2}", floatval, shortVal, doubleResult);

                shortResult = (short)floatval;
                Console.WriteLine("Explicit, -> short: {0} -> {1}", floatval, shortResult);

                stringResult = Convert.ToString(boolVal) +
                                Convert.ToString(doubleVal);
                Console.WriteLine("Explicit, -> string: \"{0}\" + \"{1}\" -> {2}", boolVal, doubleVal, stringResult);

                longResult = integerVal + Convert.ToInt64(stringval);
                Console.WriteLine("Mixed,    -> long: {0} + {1} -> {2}", integerVal, stringval, longResult);
                Console.ReadKey();




            }
            catch (Exception ex)
            { Console.WriteLine("ex.Message"); }
            }


    }

}  

