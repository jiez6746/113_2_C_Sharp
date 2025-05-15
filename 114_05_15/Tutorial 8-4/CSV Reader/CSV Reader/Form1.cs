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
            

                // 修正後的程式碼
                try
                {
                    StreamReader inputFile;
                    string line;
                    int count = 0;
                    double total = 0;
                    double average = 0;

                    char[] delimiter = { ',' }; // 修正名稱為 'delimiter'
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        inputFile = File.OpenText(openFile.FileName);

                        while (!inputFile.EndOfStream)
                        {
                            line = inputFile.ReadLine();
                            line = line.Trim(); // Remove leading and trailing whitespace
                            string[] tokens = line.Split(delimiter); // 修正變數名稱為 'delimiter'
                            total = 0; // Reset total for each line

                            for (int i = 0; i < tokens.Length; i++)
                            {
                                total += int.Parse(tokens[i]);
                            }
                            average = (double)total / (tokens.Length - 1); // 修正分母為 tokens.Length - 1
                            averagesListBox.Items.Add("第" + (++count) + "位同學的平均分數為: " + average);
                        }

                     
                    }
                    else
                    {
                        MessageBox.Show("未選取檔案。");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("檔案無法開啟: " + ex.Message); // 使用變數 'ex' 顯示錯誤訊息
                }
            }
        
        

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
