using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Cryptography;

namespace PasswordManagement
{
    public partial class Form1 : Form
    {
        public int dispHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        public int dispWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;

        public Form1()
        {
            InitializeComponent();
            Trace.WriteLine("\n" + dispHeight + "\n" + dispWidth);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string character = "abcdefghijklmnopqrstuvwxyz";
            int randInt = 0;
            string cachestring = "";

            if (radioButton1.Checked == true)
            {
                character += "0123456789";
            }

            if (textBox4.Text != null)
            {
                character += textBox4.Text;
            }
                //character += "!"#$%&\'()*+,-./:;<=>?@[\]^_`{|}~"
            if (radioButton3.Checked == true)
            {
                character += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            for (int i = 0; i < int.Parse(textBox3.Text); i++)
            {
                Random rand = new Random();
                randInt = rand.Next(0, character.Length);
                cachestring += character[randInt];
            }

            textBox5.Text = cachestring;
            //Trace.WriteLine(cachestring);
            //Trace.WriteLine(character.ToUpper());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

    }
}
