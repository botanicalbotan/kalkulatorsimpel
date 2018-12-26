using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator_Simpel
{
    public partial class Form1 : Form
    {
        private bool shift;
        private string tandasebelumnya;
        private int hasil;

        public Form1()
        {
            InitializeComponent();
            clear();

            tandasebelumnya = "";
            shift = true;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addkeyword_Click(object sender, EventArgs e) {
            if (tbHasil.Text.Equals("0") || shift == false) {
                tbHasil.Clear();
            }

            String s = (sender as Button).Text;
            tbHasil.Text += s;
            shift = true;
        }

        private void process_Click(object sender, EventArgs e) {
            if (shift)
            {
                Console.WriteLine((sender as Button).Text);
                int temp;
                bool parsing = int.TryParse(tbHasil.Text, out temp);

                if ((sender as Button).Text.Equals("="))
                {
                    tbHasil.Text = hasil.ToString();
                    Console.WriteLine("eyy");
                }
                else if (tandasebelumnya.Equals("+")) {
                    this.hasil += temp;
                } else if (tandasebelumnya.Equals("-"))
                {
                    this.hasil -= temp;
                }
                else if (tandasebelumnya.Equals("x"))
                {
                    this.hasil *= temp;
                }
                else if (tandasebelumnya.Equals("/"))
                {
                    this.hasil /= temp;
                }
                else if (tandasebelumnya.Equals(""))
                {
                    this.hasil = temp;
                }
                //else if ((sender as Button).Text.Equals("+"))
                //{

                //}
                if (!(sender as Button).Text.Equals("="))
                {
                    tandasebelumnya = (sender as Button).Text;
                    tbpencet.Text += temp + " " + (sender as Button).Text + " ";

                    shift = false;
                }
            }
            else {

            }
        }

        private void clear() {
            tbHasil.Clear();
            tbpencet.Clear();
            tbHasil.Text = "0";
        }
    }
}
