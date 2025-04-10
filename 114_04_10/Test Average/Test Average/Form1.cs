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

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The Average method accepts an int array argument
        // and returns the Average of the values in the array.
        private   Average(   )
        {
            
        }

        // The Highest method accepts an int array argument
        // and returns the highest value in that array.
        private Highest(int[] scores)
        {
           int highest = scores[0];
            for (int index = 1; index < scores.Length; index++)
            {
                if (scores[index] > highest)
                    highest = scores[index];
            }
            return highest;





        }

        // The Lowest method accepts an int array argument
        // and returns the lowest value in that array.
        private  Lowest(   )
        {
           
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48;
            int[] testScores = new int[SIZE];
            int index = 0;
            int highestScore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // Open the file.
                    inputFile = File.OpenText(openFile.FileName);
                    // Read the test scores from the file.
                    while (!inputFile.EndOfStream && index < SIZE)
                    {
                        testScores[index] = Convert.ToInt32(inputFile.ReadLine());
                        index++;
                    }
                    // Close the file.
                    inputFile.Close();
                    // Call the Average method and assign its return value to averageScore.
                    averageScore = Average(testScores);
                    // Call the Highest method and assign its return value to highestScore.
                    highestScore = Highest(testScores);
                    // Call the Lowest method and assign its return value to lowestScore.
                    lowestScore = Lowest(testScores);
                    // Display the results in a message box.
                    averageScorelabel.Text = averageScore.ToString("n1");
                    highestScoreLabel.Text = highestScore.ToString();
                    lowestScoreLabel.Text = lowestScore.ToString();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

            }







        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
