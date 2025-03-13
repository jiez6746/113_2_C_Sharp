using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program5_9
{
    public partial class Form1 : Form
    {
        Random random = new Random(); // Create a random object
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           int n1 = random.Next(1, 7); //產生1-7的隨機變數，有效範圍在button1_Click中
           int n2 = random.Next(1, 7); //產生1-7的隨機變數，有效範圍在button1_Click中

            switch (n1) 
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.Die1;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.Die2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.Die3;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.Die4;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources.Die5;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources.Die6;
                    break;

            }

            switch (n2)
            {
                case 1:
                    pictureBox2.Image = Properties.Resources.Die1;
                    break;
                case 2:
                    pictureBox2.Image = Properties.Resources.Die2;
                    break;
                case 3:
                    pictureBox2.Image = Properties.Resources.Die3;
                    break;
                case 4:
                    pictureBox2.Image = Properties.Resources.Die4;
                    break;
                case 5:
                    pictureBox2.Image = Properties.Resources.Die5;
                    break;
                case 6:
                    pictureBox2.Image = Properties.Resources.Die6;
                    break;



                     





            }


            }
    }
}
