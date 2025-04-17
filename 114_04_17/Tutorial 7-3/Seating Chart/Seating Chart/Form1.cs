using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            const int ROWS = 6;
            const int COLS = 4;
            int row;
            int col;
            decimal[,] seatPrice = {{450m, 450m, 450m, 450m},
                                  {425m, 425m, 425m, 425m},
                                  {400m, 400m, 400m, 400m},
                                  {375m, 375m, 375m, 375m},
                                  {375m, 375m, 375m, 375m},
                                  {350m, 350m, 350m, 350m} };

            if (int.TryParse(rowTextBox.Text, out row))
            {
                if (int.TryParse(colTextBox.Text, out col))
                {
                    if (row >= 0 && row < ROWS)
                    {

                        if (col >= 0 && col < COLS)
                        {
                            priceLabel.Text = seatPrice[row, col].ToString("C");

                        }
                        else
                        {

                            MessageBox.Show("行編號0~3!");
                            colTextBox.Focus();
                            return;

                        }

                    }
                    else
                    {

                        MessageBox.Show("列標號0~5!");
                        rowTextBox.Focus();
                        return;

                    }



                }

                else
                {
                    MessageBox.Show("請輸入有效的行號");
                    rowTextBox.Focus();
                    return;

                }
            }
            else
            {

                MessageBox.Show("請輸入有效的列號");
                rowTextBox.Focus();
                return;

            }


        }
    

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
