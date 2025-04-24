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
        private ListBox sortedScoresListBox;
        private Button sortButton;

        public Form1()
        {
            InitializeComponent();

            // 設定表單標題
            this.Text = "測試平均";

            // 初始化排序後的 ListBox
            sortedScoresListBox = new ListBox
            {
                Location = new Point(250, 100),
                Size = new Size(200, 150)
            };
            this.Controls.Add(sortedScoresListBox);

            // 初始化排序按鈕
            sortButton = new Button
            {
                Text = "排序",
                Location = new Point(250, 270),
                Size = new Size(100, 30)
            };
            sortButton.Click += SortButton_Click;
            this.Controls.Add(sortButton);
        }

        // 計算平均分數
        private double Average(int[] scores)
        {
            int total = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                total += scores[i];
            }
            return (double)total / scores.Length;
        }

        // 找出最高分
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

        // 找出最低分
        private int Lowest(int[] scores)
        {
            int lowest = scores[0];
            for (int index = 1; index < scores.Length; index++)
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
                    // 開啟檔案
                    inputFile = File.OpenText(openFile.FileName);

                    // 清空 ListBox
                    testScoresListBox.Items.Clear();

                    // 從檔案讀取分數
                    while (!inputFile.EndOfStream && index < SIZE)
                    {
                        testScores[index] = Convert.ToInt32(inputFile.ReadLine());
                        testScoresListBox.Items.Add(testScores[index]);
                        index++;
                    }

                    // 關閉檔案
                    inputFile.Close();

                    // 計算平均分數、最高分和最低分
                    averageScore = Average(testScores);
                    highestScore = Highest(testScores);
                    lowestScore = Lowest(testScores);

                    // 顯示結果
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
            // 關閉表單
            this.Close();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            // 假設分數來源
            int[] scores = testScoresListBox.Items.Cast<int>().ToArray();

            // 排序分數
            var sortedScores = scores.OrderBy(s => s).ToArray();

            // 清空排序後的 ListBox 並顯示排序後的分數
            sortedScoresListBox.Items.Clear();
            foreach (var score in sortedScores)
            {
                sortedScoresListBox.Items.Add(score);
            }
        }
    }
}
