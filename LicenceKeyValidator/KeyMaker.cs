using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace LicenceKeyValidator
{
    public class KeyMaker
    {
        public KeyMaker(System.Security.SecureString validationKey)
        {
            System.Security.SecureString skey = new System.Security.SecureString();

            foreach (char c in "Rumesh851")
            {
                skey.AppendChar(c);
            }

            if (validationKey == skey)
            {
                throw new Exception("Error!!!");
            }

        }

        private string identifier(string wmiClass, string wmiProperty)
        //Return a hardware identifier
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        public string HDDId
        {
            get
            {

                string hdd = "";
                hdd = identifier("Win32_DiskDrive", "SerialNumber");
                return hdd;
            }
        }
        public string ProcessorId
        {
            get
            {

                string procSerial = "";
                procSerial = identifier("Win32_BaseBoard", "SerialNumber");
                return procSerial;
            }
        }

        private string FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            string s = Encoding.ASCII.GetString(raw);

            return s;
        }
        private string ToHex(string str)
        {

            byte[] ba = Encoding.Default.GetBytes(str);
            var hexString = BitConverter.ToString(ba);
            return hexString;
        }

        public string MachineKey
        {
            get
            {

                string HDDSerial, ProcessorSerial, key;
                Int16 checksum;

                HDDSerial = ToHex(HDDId).Substring(0, 5).PadLeft(5, 'F');
                ProcessorSerial = ToHex(ProcessorId).Substring(0, 5).PadLeft(5, 'F');


                return "";
            }
        }

        public string GenerateSerial(string productCode, int nosUsers, int expiaryMonths)
        {
            // Make the variable that holds the serial
            string serial="";
            Random ran = new Random();

            // 
            // Make the random key (within base 36)
            // 

            int key = ran.Next(0, 60466175);

            // 
            // Create the list that will contain the 'Char Arrays'
            // 
            List<List<string>> lst = new List<List<string>>();


            string[] arr1 = new[] { "A", "A", "B", "C", "C", "D", "E", "E", "F", "G", "G", "H", "I", "I", "J", "K", "K", "L", "M", "M", "N", "O", "O", "P", "Q", "Q", "R", "S", "S", "T", "U", "U", "V", "W", "W", "X", "Y", "Y", "Z", "0", "0", "1", "2", "2", "3", "4", "4", "5", "6", "6", "7", "8", "8", "9" };
            string[] arr2 = new[] { "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] arr3 = new[] { "A", "E", "I", "O", "U", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] arr4 = new[] { "0", "2", "4", "6", "8", "A", "C", "E", "G", "I", "K", "M", "O", "Q", "S", "U", "W", "Y" };
            string[] arr5 = new[] { "0", "1", "2", "6", "7", "8", "A", "B", "C", "G", "H", "I", "M", "N", "O", "S", "T", "U", "Y", "Z" };
            string[] arr6 = new[] { "L", "X", "M", "N", "T", "O", "P", "U", "V", "Q", "W", "A", "K", "0", "2", "4", "5", "6", "8", "9" };
            string[] arr7 = new[] { "N", "T", "O", "S", "P", "R", "I", "E", "L", "X", "Q", "Z", "C", "B", "H", "8", "7", "2", "1", "6", "0", "3" };
            string[] arr8 = new[] { "L", "S", "D", "M", "N", "O", "Q", "R", "S", "N", "V", "Q", "Y", "Q", "K", "X", "C", "A", "4", "5", "9", "2" };
            string[] arr9 = new[] { "9", "7", "6", "4", "3", "1", "Q", "E", "T", "U", "O", "A", "S", "F", "H", "K", "Z", "C", "B", "M" };
            string[] arr10 = new[] { "9", "8", "7", "3", "2", "1", "5", "5", "5", "W", "R", "Y", "I", "P", "S", "F", "H", "K", "Z", "C", "B", "M" };
            string[] arr11 = new[] { "Q", "R", "I", "A", "F", "J", "Z", "V", "M", "E", "U", "P", "D", "H", "L", "C", "N", "0", "2", "3", "5", "7", "8" };
            string[] arr12 = new[] { "Q", "A", "Z", "E", "D", "C", "T", "G", "B", "U", "J", "M", "O", "L", "7", "4", "5", "6", "3", "2" };
            string[] arr13 = new[] { "Q", "A", "S", "E", "R", "F", "G", "H", "Y", "U", "J", "K", "I", "O", "L", "Z", "X", "S", "D", "F", "V", "B", "G", "H", "J", "M", "K", "9", "5", "1", "7", "5", "3" };
            string[] arr14 = new[] { "Q", "W", "E", "T", "Y", "U", "O", "P", "A", "D", "F", "G", "J", "K", "L", "X", "C", "V", "N", "M", "1", "4", "6", "9" };
            string[] arr15 = new[] { "Q", "A", "Z", "X", "C", "D", "E", "R", "T", "G", "B", "N", "M", "J", "U", "I", "O", "L", "1", "5", "4", "8", "6", "2", "3" };
            string[] arr16 = new[] { "W", "E", "D", "C", "V", "B", "G", "T", "Y", "U", "J", "M", "K", "L", "O", "H", "F", "S", "1", "5", "4", "2", "3" };
            string[] arr17 = new[] { "O", "I", "U", "T", "G", "B", "C", "X", "Z", "Q", "W", "E", "R", "F", "V", "B", "N", "M" };
            string[] arr18 = new[] { "Q", "A", "Z", "X", "S", "D", "C", "V", "F", "R", "T", "G", "B", "N", "H", "J", "M", "K", "I", "O", "L", "P", "1", "3", "2", "5", "6", "7", "9" };
            string[] arr19 = new[] { "L", "I", "A", "M", "I", "S", "C", "O", "O", "L", "I", "S", "N", "T", "H", "E", "3", "3", "3" };
            // VVVVVVV
            string[] arr20 = new[] { "L", "S", "D", "I", "S", "C", "O", "O", "L", "S", "O", "I", "S", "C", "O", "C", "A", "I", "N", "E", "A", "N", "D", "P", "O", "T", "A", "N", "D", "M", "E", "T", "H" };
            // ^^^^^^^ This could explain a few things =]

            // 
            // Add arrays as lists
            // 
            lst.Add(new List<string>(arr1));
            lst.Add(new List<string>(arr2));
            lst.Add(new List<string>(arr3));
            lst.Add(new List<string>(arr4));
            lst.Add(new List<string>(arr5));
            lst.Add(new List<string>(arr6));
            lst.Add(new List<string>(arr7));
            lst.Add(new List<string>(arr8));
            lst.Add(new List<string>(arr9));
            lst.Add(new List<string>(arr10));
            lst.Add(new List<string>(arr11));
            lst.Add(new List<string>(arr12));
            lst.Add(new List<string>(arr13));
            lst.Add(new List<string>(arr14));
            lst.Add(new List<string>(arr15));
            lst.Add(new List<string>(arr16));
            lst.Add(new List<string>(arr17));
            lst.Add(new List<string>(arr18));
            lst.Add(new List<string>(arr19));
            lst.Add(new List<string>(arr20));

            // Convert the key to Base36 and prepend to the serial code

            serial += ToBase36(key);
            // Append extra 0's if the key isn't already five characters long
            while (serial.Length != 5)
                serial = "0" + serial;

            // 
            // Initialize the random using Random(key)
            // 
            Random r1 = new Random(key);

            // 
            // Generate the key using the unique 'array' for each character.
            // 

            int x;
            while (serial.Length != 29)
            {
                x = serial.Length;
                // Use modulus to see if this is the time for a hyphen ("-")
                if (x % 6 == 5)
                    serial += "-";
                else
                    serial += lst[x - (5 + (x + 1) / 6)][r1.Next(0, lst[x - (5 + (x + 1) / 6)].Count - 1)];
            }

            // Return the serial key
            string [] serialContent = serial.Split('-');

            serialContent[2] = ToHex(productCode).Replace("-","").PadLeft(5, 'F').Substring(0, 5);
            serialContent[3] = ToHex(nosUsers.ToString()).Replace("-", "").PadLeft(5, 'F').Substring(0, 5);
            serialContent[4] = ToHex(expiaryMonths.ToString()).Replace("-", "").PadLeft(5, 'F').Substring(0, 5);
            return string.Join("-",serialContent);
        }

        public double FromBase36(string IBase36)
        {
            IBase36 = IBase36.ToUpper();
            string[] Base36 = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int i;
            double v = 0;
            for (i = IBase36.Length-1; i >= 0; i --)
            {
                double bc = Math.Pow(Convert.ToDouble(36), Convert.ToDouble((IBase36.Length - 1) - i));
                if (Base36.Contains(IBase36.ToCharArray()[i].ToString()))
                    v += Array.LastIndexOf(Base36, IBase36.ToCharArray()[i].ToString()) * bc;
                else
                    throw new InvalidCastException();
            }
            return v;
        }

        public string ToBase36(long IBase36)
        {
            string[] Base36 = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string v = "";
            long i;
            long a;
            while (IBase36 >= 1)
            {
                i = IBase36 % 36;
                v = Base36[i] + v;
                IBase36 = Math.DivRem(IBase36, 36, out a);
            }
            return v;
        }

        public string SerialFromKey(string Key)
        {
            // Make the variable that holds the serial
            string serial = "" ;
            // 
            // Create the list that will contain the 'Char Arrays'
            // 
            List<List<string>> lst = new List<List<string>>();


            string[] arr1 = new[] { "A", "A", "B", "C", "C", "D", "E", "E", "F", "G", "G", "H", "I", "I", "J", "K", "K", "L", "M", "M", "N", "O", "O", "P", "Q", "Q", "R", "S", "S", "T", "U", "U", "V", "W", "W", "X", "Y", "Y", "Z", "0", "0", "1", "2", "2", "3", "4", "4", "5", "6", "6", "7", "8", "8", "9" };
            string[] arr2 = new[] { "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] arr3 = new[] { "A", "E", "I", "O", "U", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] arr4 = new[] { "0", "2", "4", "6", "8", "A", "C", "E", "G", "I", "K", "M", "O", "Q", "S", "U", "W", "Y" };
            string[] arr5 = new[] { "0", "1", "2", "6", "7", "8", "A", "B", "C", "G", "H", "I", "M", "N", "O", "S", "T", "U", "Y", "Z" };
            string[] arr6 = new[] { "L", "X", "M", "N", "T", "O", "P", "U", "V", "Q", "W", "A", "K", "0", "2", "4", "5", "6", "8", "9" };
            string[] arr7 = new[] { "N", "T", "O", "S", "P", "R", "I", "E", "L", "X", "Q", "Z", "C", "B", "H", "8", "7", "2", "1", "6", "0", "3" };
            string[] arr8 = new[] { "L", "S", "D", "M", "N", "O", "Q", "R", "S", "N", "V", "Q", "Y", "Q", "K", "X", "C", "A", "4", "5", "9", "2" };
            string[] arr9 = new[] { "9", "7", "6", "4", "3", "1", "Q", "E", "T", "U", "O", "A", "S", "F", "H", "K", "Z", "C", "B", "M" };
            string[] arr10 = new[] { "9", "8", "7", "3", "2", "1", "5", "5", "5", "W", "R", "Y", "I", "P", "S", "F", "H", "K", "Z", "C", "B", "M" };
            string[] arr11 = new[] { "Q", "R", "I", "A", "F", "J", "Z", "V", "M", "E", "U", "P", "D", "H", "L", "C", "N", "0", "2", "3", "5", "7", "8" };
            string[] arr12 = new[] { "Q", "A", "Z", "E", "D", "C", "T", "G", "B", "U", "J", "M", "O", "L", "7", "4", "5", "6", "3", "2" };
            string[] arr13 = new[] { "Q", "A", "S", "E", "R", "F", "G", "H", "Y", "U", "J", "K", "I", "O", "L", "Z", "X", "S", "D", "F", "V", "B", "G", "H", "J", "M", "K", "9", "5", "1", "7", "5", "3" };
            string[] arr14 = new[] { "Q", "W", "E", "T", "Y", "U", "O", "P", "A", "D", "F", "G", "J", "K", "L", "X", "C", "V", "N", "M", "1", "4", "6", "9" };
            string[] arr15 = new[] { "Q", "A", "Z", "X", "C", "D", "E", "R", "T", "G", "B", "N", "M", "J", "U", "I", "O", "L", "1", "5", "4", "8", "6", "2", "3" };
            string[] arr16 = new[] { "W", "E", "D", "C", "V", "B", "G", "T", "Y", "U", "J", "M", "K", "L", "O", "H", "F", "S", "1", "5", "4", "2", "3" };
            string[] arr17 = new[] { "O", "I", "U", "T", "G", "B", "C", "X", "Z", "Q", "W", "E", "R", "F", "V", "B", "N", "M" };
            string[] arr18 = new[] { "Q", "A", "Z", "X", "S", "D", "C", "V", "F", "R", "T", "G", "B", "N", "H", "J", "M", "K", "I", "O", "L", "P", "1", "3", "2", "5", "6", "7", "9" };
            string[] arr19 = new[] { "L", "I", "A", "M", "I", "S", "C", "O", "O", "L", "I", "S", "N", "T", "H", "E", "3", "3", "3" };
            string[] arr20 = new[] { "L", "S", "D", "I", "S", "C", "O", "O", "L", "S", "O", "I", "S", "C", "O", "C", "A", "I", "N", "E", "A", "N", "D", "P", "O", "T", "A", "N", "D", "M", "E", "T", "H" };

            // 
            // Add arrays as lists
            // 
            lst.Add(new List<string>(arr1));
            lst.Add(new List<string>(arr2));
            lst.Add(new List<string>(arr3));
            lst.Add(new List<string>(arr4));
            lst.Add(new List<string>(arr5));
            lst.Add(new List<string>(arr6));
            lst.Add(new List<string>(arr7));
            lst.Add(new List<string>(arr8));
            lst.Add(new List<string>(arr9));
            lst.Add(new List<string>(arr10));
            lst.Add(new List<string>(arr11));
            lst.Add(new List<string>(arr12));
            lst.Add(new List<string>(arr13));
            lst.Add(new List<string>(arr14));
            lst.Add(new List<string>(arr15));
            lst.Add(new List<string>(arr16));
            lst.Add(new List<string>(arr17));
            lst.Add(new List<string>(arr18));
            lst.Add(new List<string>(arr19));
            lst.Add(new List<string>(arr20));

            // 
            // Initialize the random using Random(key)
            // 
            Random r1 = new Random(int.Parse( Key));

            serial = ToBase36(int.Parse( Key));
            // Append extra 0's if the key isn't already five characters long
            while (serial.Length != 5)
                serial = "0" + serial;

            // 
            // Generate the key using the unique 'array' for each character.
            // 
            int x;
            while (serial.Length != 29)
            {
                x = serial.Length;
                // Use modulus to see if a hyphen ("-") belongs here
                if (x % 6 == 5)
                    serial += "-";
                else
                    serial += lst[x - (5 + (x + 1) / 6)][r1.Next(0, lst[x - (5 + (x + 1) / 6)].Count - 1)];
            }

            return serial;
        }
        public bool ValidateCode(string serial)
        {


            if (serial == SerialFromKey(FromBase36(serial.Substring(0, 5)).ToString()))
                return true;
            else
                return false;
        }

    }
}
