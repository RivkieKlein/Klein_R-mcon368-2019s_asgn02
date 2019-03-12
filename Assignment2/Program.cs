using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            int cloudStorage = 500;
            int networkSpeed = 10000;

            Computer defaultPrototype= new Computer();
            defaultPrototype.Antenna = null;
            defaultPrototype.RAM = 2000;
            defaultPrototype.licensesPerSoftware = null;
            defaultPrototype.HardDriveCap = 250;
            Computer userPrototype=null;

            Computer[] computers;
            int number;

            Console.WriteLine("What is the maximum number of computers you need to track");
            GetIntFromUser(out number, 5, 20, 10);

            computers = new Computer[number];

            int choice;

            do
            {
                choice = Menu();

                switch (choice)
                {
                    case 1 :
                        computers[number - 1] = getComputerInfo();
                        Console.WriteLine("Computer added. ID is " + computers[number - 1].ID);
                        number--;
                        break;

                    case 2:
                        Console.WriteLine("what is the id  of the computer you wish to make your prototype?");
                        String id = Console.ReadLine();
                        for(int c =0; c< computers.Length; c++)
                        {
                            if (id == computers[c].ID)
                            {
                                userPrototype = computers[c];
                            }
                        }

                        break;

                    case 3:
                        userPrototype = null;
                        Console.WriteLine("prototype removed");
                        break;

                    case 4:
                        if (DoubleIntNotPastMax(ref cloudStorage, 16000, false))
                        {
                            Console.WriteLine("cloud storage successfully upgraded");
                        }
                        else
                        {
                            Console.WriteLine("Cannot double cloud storage. it would exceed the max of 16000");
                        }
                        break;

                    case 5:
                        if( HalveValueNotPastMin(ref cloudStorage, 500, true))
                        {
                            Console.WriteLine("cloud storage successfully downgraded");
                        }
                        else
                        {
                            Console.WriteLine("cloud storage set to minimum of 500");
                        }
                        break;

                    case 6:
                        if (DoubleIntNotPastMax(ref networkSpeed, 250000, true))
                        {
                            Console.WriteLine("network speed successfully upgraded");
                        }
                        else
                        {
                            Console.WriteLine("network speed set to 250000 since it could not be upgraded past that");
                        }
                        break;
                        

                    case 7:
                        if (HalveValueNotPastMin(ref cloudStorage, 10000, false))
                        {
                            Console.WriteLine("network successfully downgraded");
                        }
                        else
                        {
                            Console.WriteLine("network speed could not be downgraded since it would go below the minimum of 10000");
                        }
                        break;

                    case 8:
                        Console.WriteLine("Enter the array index of the computer of which you'd like a summary");
                        int index = Convert.ToInt32(Console.ReadLine());
                        if (computers[index] != null)
                        {
                            Console.WriteLine(computers[index]);
                        }
                        else
                        {
                            Console.WriteLine(defaultPrototype);
                        }
                        break;

                    case 9:
                        break;

                    case 10:
                        break;

                    case 0:
                        Console.WriteLine("Thank you for exploring computers with us today. Good bye.");
                        break;

                 


                }





            } while (choice != 0);



        }

        

        public static int Menu()
        {
            Console.WriteLine("Please enter the number corresponding to a menu option. Enter 0 to exit");
            Console.WriteLine("1. Add a computer");
            Console.WriteLine("2. Specify which computer is your prototype");
            Console.WriteLine("3. Remove your prototype computer");
            Console.WriteLine("4. Upgrade cloud storage");
            Console.WriteLine("5. Downgrade cloud storage");
            Console.WriteLine("6. Upgrade network speed");
            Console.WriteLine("7. Downgrade network speed");
            Console.WriteLine("8. Get summary of a computers specs");
            Console.WriteLine("9. Summary of stats of all your computers");
            Console.WriteLine("10. Summary of stats of specific range of computers");

            return Convert.ToInt32(Console.ReadLine());
        }

        public static Computer getComputerInfo()
        {
            Computer comp = new Computer();

            Console.WriteLine("does the computer have an antenna? (true/false");
            comp.Antenna = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("What is the hard drive capacity of the computer. If the computer is not built to support a hard" +
                " drive just leave this field blank and hit enter ");
            String cap = Console.ReadLine();
            if (string.IsNullOrEmpty(cap))
            {
                comp.HardDriveCap = null;
            }
            else
            {
                comp.HardDriveCap = Convert.ToDouble(cap);
            }

            Console.WriteLine("how much RAM does the computer have");
            comp.RAM = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("is this computer equipped for extra software? true/false");
            if (Convert.ToBoolean(Console.ReadLine()))
            {
                comp.licensesPerSoftware = new int?[5];
                Console.WriteLine("please enter the number of licenses this device has for 5 different pieces of software or null if that software is not installed (ex. 1 12 0 null 3) ");
                string[] words = Console.ReadLine().Split(' ');
                for(int c=0; c < comp.licensesPerSoftware.Length; c++)
                {
                    if (words[c] != "null")
                    {
                        comp.licensesPerSoftware[c] = Convert.ToInt32(words[c]);
                    }
                    else
                    {
                        comp.licensesPerSoftware[c] = null;
                    }
                }
            }
            else
            {
                comp.licensesPerSoftware = null;
            }
            

            return comp;
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
