using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Decoder
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            txtResult.Text = Process(tbInput.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "암호문";
            tbInput.Text = "";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private string Process(string sValue)
        {
            string sResult = "";

            for (int i = 0; i < sValue.Length; i++)
            {
                if (sValue[i] == ' ') sResult += " ";
                else if (sValue[i] == 'a') sResult += "x";
                else if (sValue[i] == 'b') sResult += "y";
                else if (sValue[i] == 'c') sResult += "z";
                else
                {
                    char value = (char)(sValue[i] - 3);
                    sResult += value.ToString();
                }
            }

            SaveFile();

            return sResult;
        }

        private void SaveFile()
        {
            string sValue = tbInput.Text;

            StreamWriter sw = new StreamWriter("data.txt");
            sw.WriteLine(sValue);

            sw.Close();
        }

        private void LoadFile()
        {
            if (!File.Exists("data.txt"))
                return;

            try
            {
                StreamReader sr = new StreamReader("data.txt");
                string sValue = sr.ReadLine();

                sr.Close();

                tbInput.Text = sValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
