using System;

using System.Text;


namespace Assignment2
{
    class Computer
    {
        readonly string iD;
        private static string lastID;

      
        private double? _hardDriveCap;
        private int _RAM;
        public int?[] licensesPerSoftware;
        public bool? Antenna { get; set; }



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


        

        public double? HardDriveCap
        {
            get
            {
                return _hardDriveCap;
            }
            set
            {
                if (value >= 0)
                {
                    _hardDriveCap = value;
                }
            }
        }

        public  int RAM
        {
            get
            {
                int amount = _RAM;
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
                _RAM = value >= 1000 ? value : 1000;
            }
        }
        override
        public String ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Computer #"+ iD+ " :");
            output.AppendLine(Antenna != null ? "Has antenna: "+Antenna : "Cellular antenna not applicable for this device");
            output.AppendLine(HardDriveCap != null ? "Hard drive capacity: " + HardDriveCap : "Not hard drive compatable");
            output.AppendLine("RAM: " + RAM);


            if (licensesPerSoftware!=null)
            {
                for(int c =0; c< 5; c++)
                {
                   output.AppendLine(licensesPerSoftware[c] == null ? "Software " + ((c + 1)) + " is not installed" : "Software " + (c + 1) + " has "+licensesPerSoftware[c]+" installed");

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
