using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Computer
    {
        readonly string iD;
        private static string lastID;

      
        private double? hardDriveCap;
        private int rAM;
        public int?[] licensesPerSoftware;



        public Computer()
        {
            if (lastID == null)
            {
                iD = "0";
                lastID = iD;
            }
            else
            {
                iD = (Int32.Parse(lastID) + 1).ToString();
                lastID = iD;
            }
        }




        
        public string ID { get { return iD; } }


        public bool? Antenna { get; set; }

        public double? HardDriveCap
        {
            get
            {
                return hardDriveCap;
            }
            set
            {
                if (value >= 0)
                {
                    hardDriveCap = value;
                }

        
                
            }
        }

        public  int RAM
        {
            get
            {
                int amount = rAM;
                if (Antenna==true)
                {
                    amount = amount - 100;
                }
                else
                {
                    amount = amount - 50;
                }
                if (licensesPerSoftware != null)
                {
                    for (int c = 0; c < licensesPerSoftware.Length; c++)
                    {
                        if (licensesPerSoftware[c].HasValue)
                        {
                            if (licensesPerSoftware[c] > 0)
                            {
                                amount = amount - 10;
                            }
                        }
                    }
                }
                return amount;
            }
            set
            {
                if (value >= 1000)
                {
                    rAM = value;
                }
            }
        }
        override
        public String ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Computer #"+ iD+ " :");
            if (Antenna!=null)
            {
                output.AppendLine("Has antenna: " + Antenna);
            }
            else
            {
                output.AppendLine("Cellular antenna not applicable for this device");
            }
            
            if (HardDriveCap != null)
            {
                output.AppendLine("Hard drive capacity: " +HardDriveCap);
            }
            else
            {
                output.AppendLine("Not hard drive compatable");
            }

            output.AppendLine("RAM: " + RAM);

            if (licensesPerSoftware!=null)
            {
                for(int c =0; c< licensesPerSoftware.Length; c++)
                {
                    if (licensesPerSoftware[c] != null)
                    {
                        output.AppendLine("Software " + c + 1 + " has " + licensesPerSoftware[c] + " licenses");
                    }
                    else
                    {
                        output.AppendLine("Software "+c+1+" is not installed"); 
                    }
                }
            }
            else
            {
                output.AppendLine("Device not equipped for extra storage");
            }



            return output.ToString();
        }
    }
}
