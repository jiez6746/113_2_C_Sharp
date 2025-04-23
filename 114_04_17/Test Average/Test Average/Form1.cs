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
        private double  Average(int[] scores)
        {
            int total = 0 ;
            for (int i = 0; i < scores.Length; i++)
            {
                total += scores[i];
            }
            return (double)total / scores.Length;

        }

        // The Highest method accepts an int array argument
        // and returns the highest value in that array.
        private int Highest(int[] scores)
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
        private int Lowest(int[] scores)
        {
            int lowest = scores[0];
            for(int index =1; index <scores.Length; index++)
            { 
              if (scores[index] < lowest)
              lowest = scores[index];

            }
            return lowest;

        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48;
            int[] testScores = new int[SIZE];
            int index = 0;
            int highestScore = 0;
            int lowestScore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // Open the file.  
                    inputFile = File.OpenText(openFile.FileName);
                    // Clear the ListBox before adding new items.  
                    testScoresListBox.Items.Clear();
                    // Read the test scores from the file.  
                    while (!inputFile.EndOfStream && index < SIZE)
                    {
                        testScores[index] = Convert.ToInt32(inputFile.ReadLine());
                        // Add the score to the ListBox.  
                        testScoresListBox.Items.Add(testScores[index]);
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
                    averageScoreLabel.Text = averageScore.ToString("n1");
                    highScoreLabel.Text = highestScore.ToString();
                    lowScoreLabel.Text = lowestScore.ToString();
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
