using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        private int CloudStorage = 500;
        private int Netw
        public static void Main(string[] args)
        {
            
        }

        public static bool GetIntFromUser(out int number, int min, int max, int defaultVal)
        {
            Console.WriteLine("Please enter a number between" + min+" and "+ max);
            int tempNumber = Convert.ToInt32(Console.ReadLine());

            if (tempNumber >= min && tempNumber <= max)
            {
                number = tempNumber;
                return true;
            }
            else
            {
                number = defaultVal;
                return false;
            }

        }

        public static bool DoubleIntNotPastMax(ref int number, int max, bool setToMax )
        {
            if ((number * 2) <= max)
            {
                number = number * 2;
                return true;
               
            }
            else
            {
                if (setToMax)
                {
                    number = max;
                }
                return false;
            }
        }

        public static bool HalveValueNotPastMin(ref int number, int min, bool setToMin)
        {
            if ((number /2) >= min)
            {
                number = number / 2;
                return true;
            }
            else
            {
                if (setToMin)
                {
                    number = min;
                }
                return false;
                
            }
        }
    }
}
