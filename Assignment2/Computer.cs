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

        private bool? antenna;
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




        
        public string ID { get { return iD } }


        public bool Antenna { get; set; }

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
                if (antenna==true)
                {
                    amount = amount - 100;
                }
                else
                {
                    amount = amount - 50;
                }
                for (int c =0; c<licensesPerSoftware.Length; c++)
                {
                    if (licensesPerSoftware[c].HasValue)
                    {
                        if (licensesPerSoftware[c] > 0)
                        {
                            amount = amount + 10;
                        }
                    }
                }
            }
            set
            {
                if (value >= 1000)
                {
                    rAM = value;
                }
            }
        }
    }
}
