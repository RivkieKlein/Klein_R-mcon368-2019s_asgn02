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

            Computer userPrototype = null; 

            Computer[] computers;
            int number;
            int computerPosition=0;
            
            

            Console.WriteLine("What is the maximum number of computers you need to track");
            if(!GetIntFromUser(out number, 5, 20, 10))
            {
                Console.WriteLine("Invalid numbers of computers. Program will default to track a max of 100 computers");
            }

            computers = new Computer[number];

            int choice;

            do
            {
                choice = Menu();

                switch (choice)
                {
                    case 1 :
                        computers[computerPosition] = getComputerInfo();
                        Console.WriteLine("Computer added. ID is " + computers[computerPosition].ID);
                        computerPosition++ ;
                        
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
                        Console.WriteLine(computers[index] ?? defaultPrototype);
                        break;

                    case 9:
                        ComputerAverages(0, computerPosition, computers, userPrototype, defaultPrototype);
                        Console.WriteLine(networkSpeed);
                        Console.WriteLine(cloudStorage);
                        break;

                    case 10:

                        Console.WriteLine("Enter index of start of summary");
                        int start = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter index of end of summart");
                        int end = Convert.ToInt32(Console.ReadLine());
                        ComputerAverages(start, end, computers, userPrototype, defaultPrototype);
                        Console.WriteLine(networkSpeed);
                        Console.WriteLine(cloudStorage);
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
            Console.WriteLine("Does the computer have an antenna? (true/false). If the computer is not built to support an antenna" +
               "just leave this field blank and hit enter ");
            String antenna = Console.ReadLine();
            if (string.IsNullOrEmpty(antenna))
            {
                comp.Antenna = null;
            }
            else
            {
                comp.Antenna = Convert.ToBoolean(antenna);
            }


            Console.WriteLine("What is the hard drive capacity of the computer. If the computer is not built to support a hard" +
                " drive just leave this field blank and hit enter ");
            String capacity = Console.ReadLine();
            if (string.IsNullOrEmpty(capacity))
            {
                comp.HardDriveCap = null;
            }
            else
            {
                comp.HardDriveCap = Convert.ToDouble(capacity);
            }

            Console.WriteLine("how much RAM does the computer have");
            comp.RAM = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("is this computer equipped for extra software? true/false");
            if (Convert.ToBoolean(Console.ReadLine()))
            {
                comp.licensesPerSoftware = new int?[5];
                Console.WriteLine("please enter the number of licenses this device has for 5 different pieces of software or null if that software is not installed (ex. 1 12 0 null 3) ");
                String[] words = Console.ReadLine().Split(' ');
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

        
        public static void ComputerAverages(int start, int end, Computer[] computers, Computer userProto, Computer defProto)
        {
            if (computers[0] == null)
            {
                Console.WriteLine("No computers entered. Cannot complete stat averages");
                return;
            }
            int totalRam = 0;
            int numWithAntenna = 0;
            int numWithoutAntenna = 0;
            int numWithHardDrive = 0;
            double totalHardDriveCap = 0;

            int machinesWithAnySoftware = 0;
            int totalLicensesPerComputer = 0;
            int[] totalLicensesPerSoftware = { 0, 0, 0, 0, 0 };
            int[] totalCompsWithThisSoftwareInstalled = { 0, 0, 0, 0, 0 };


            for (int c = start; c < end; c++)
            {
                Computer current = (computers[c] ?? userProto ?? defProto);
                //ram calculations
                totalRam += current.RAM;

                //antenna calculations
                if (current.Antenna != null)
                {
                    if ((bool)current.Antenna)
                    {
                        numWithAntenna++;
                    }
                    else
                    {
                        numWithoutAntenna++;
                    }

                }

                //hard drive calcs
                if (current.HardDriveCap != null)
                {
                    numWithHardDrive++;
                    totalHardDriveCap += (double)current.HardDriveCap;
                }


                //software calcs
                if (current.licensesPerSoftware != null)
                {
                    machinesWithAnySoftware++;
                    for (int i = 0; i < 5; i++)
                    {
                        if (current.licensesPerSoftware[i] != null)
                        {
                            totalLicensesPerComputer += (int)current.licensesPerSoftware[i];
                            totalLicensesPerSoftware[i] += (int)current.licensesPerSoftware[i];
                            totalCompsWithThisSoftwareInstalled[i]++;
                        }
                    }
                }
            }

            Console.WriteLine("Average RAM: " + totalRam / (end-start));
            Console.WriteLine("Percent of Antenna compatible computers that actually have antenna: " + ((numWithAntenna==0&&numWithoutAntenna==0) ? "N/A no antenna compatible computers entered":((numWithAntenna / (numWithAntenna + numWithoutAntenna)) * 100) + "%"));
            Console.WriteLine("Average hard drive capacity: " + ((numWithHardDrive ==0 )? "N/A no hard drive compatible computers entered":totalHardDriveCap / numWithHardDrive +" "));
            Console.WriteLine("Average number of software licenses per computer for those with software: " + (machinesWithAnySoftware==0  ? "N/A none of the computers entered can handleextra software" : totalLicensesPerComputer / machinesWithAnySoftware+" "));
            for (int r = 0; r < 5; r++)
            {
                if (totalCompsWithThisSoftwareInstalled[r] != 0)
                {
                    Console.WriteLine("Average licenses for software " + ((r + 1)) + ": " + totalLicensesPerSoftware[r] / totalCompsWithThisSoftwareInstalled[r]);
                }
                else
                {
                    Console.WriteLine("Average licenses for computer " + ((r + 1)) + ": N/A this software is not installed on any computers" );
                }
            }

            
        }

        public static bool GetIntFromUser(out int number, int min, int max, int defaultVal)
        {
            Console.WriteLine("Please enter a number between " + min+" and "+ max);
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
