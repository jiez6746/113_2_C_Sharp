using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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

           showpicturebox(n1, pictureBox1 ); //呼叫showpicturebox方法

           showpicturebox(n2 ,pictureBox2 ); //呼叫showpicturebox方法




        }

            private void showpicturebox(int n, PictureBox pic)
         {
            switch (n)
            {
                case 1:
                    pic.Image = Properties.Resources.Die1;
                    break;
                case 2:
                    pic.Image = Properties.Resources.Die2;
                    break;
                case 3:
                    pic.Image = Properties.Resources.Die3;
                    break;
                case 4:
                    pic.Image = Properties.Resources.Die4;
                    break;
                case 5:
                    pic.Image = Properties.Resources.Die5;
                    break;
                case 6:
                    pic.Image = Properties.Resources.Die6;
                    break;

            }
        }





    }
}
