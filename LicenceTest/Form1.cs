using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LicenceTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string ToHex(string str)
        {

            byte[] ba = Encoding.Default.GetBytes(str);
            var hexString = BitConverter.ToString(ba);
            return hexString;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Security.SecureString skey = new System.Security.SecureString();

            foreach (char c in "Rumesh851")
            {
                skey.AppendChar(c);
            }

           

            string hex=ToHex("Rumesh");
            MessageBox.Show(hex.Substring(0, 8));

              // GatewayServer

           

            LicenceKeyValidator.KeyMaker o = new LicenceKeyValidator.KeyMaker(skey);

            string serial = o.GenerateSerial("APOS",3,1);
            MessageBox.Show(serial);
            MessageBox.Show(o.ValidateCode(serial).ToString());

            MessageBox.Show(o.HDDId);
            MessageBox.Show(o.ProcessorId);
        }
    }
}
