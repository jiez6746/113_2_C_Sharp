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

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile;
                string line;
                int count = 0;

                char[] delimiter = { ',' };
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);

                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine();
                        line = line.Trim();
                        string[] tokens = line.Split(delimiter);

                        if (tokens.Length < 2)
                            continue; // 跳過沒有分數的行

                        string name = tokens[0];
                        double total = 0;
                        int scoreCount = tokens.Length - 1;

                        for (int i = 1; i < tokens.Length; i++)
                        {
                            total += double.Parse(tokens[i]);
                        }
                        double average = total / scoreCount;
                        averagesListBox.Items.Add($"{name}同學的平均分數為: {average:F2}");
                        count++;
                    }
                }
                else
                {
                    MessageBox.Show("未選取檔案。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("檔案無法開啟: " + ex.Message);
            }
        }
        
        

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
