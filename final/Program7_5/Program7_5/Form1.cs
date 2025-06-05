using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 儲存隊伍名稱的清單
        List<string> team = new List<string>();

        // 儲存冠軍隊伍的清單
        List<string> winner = new List<string>();

        // 儲存冠軍年份的清單
        List<int> years = new List<int>();

        // 當表單載入時執行的事件處理函式
        private void Form1_Load(object sender, EventArgs e)
        {
            // 開啟第一個檔案
            openTeamsFile();

            // 開啟第二個檔案
            openWinnersFile();
        }

        // 開啟隊伍檔案的函式
        private void openTeamsFile()
        {
            try
            {
                // 顯示提示訊息，要求使用者選擇檔案
                MessageBox.Show("請選擇球隊檔案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 建立 OpenFileDialog 物件
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "請選擇 MLB_Teams_Translated 檔案",
                    Filter = "文字檔案 (*.txt)|*.txt",
                    Multiselect = false // 僅允許選擇單一檔案
                };

                // 顯示對話框並檢查使用者是否選擇了檔案
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 取得選擇的檔案路徑
                    string filePath = openFileDialog.FileName;

                    // 檢查檔案名稱是否正確
                    if (filePath.Contains("MLB_Teams_Translated"))
                    {
                        // 清空隊伍清單
                        team.Clear();

                        // 讀取檔案內容並存入清單
                        using (StreamReader inputFile = new StreamReader(filePath))
                        {
                            while (!inputFile.EndOfStream)
                            {
                                string line = inputFile.ReadLine();
                                if (!string.IsNullOrWhiteSpace(line))
                                {
                                    team.Add(line);
                                }
                            }
                        }

                        // 更新 ListBox 顯示
                        listBox1.Items.Clear();
                        listBox1.Items.AddRange(team.ToArray());
                    }
                    else
                    {
                        MessageBox.Show("請選擇正確的檔案：MLB_Teams_Translated。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit(); // 如果檔案不正確，關閉程式
                    }
                }
                else
                {
                    MessageBox.Show("未選擇檔案，程式即將結束。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit(); // 如果未選擇檔案，關閉程式
                }
            }
            catch (Exception ex)
            {
                // 如果發生錯誤，顯示錯誤訊息
                MessageBox.Show("開啟檔案時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // 如果發生錯誤，關閉程式
            }
        }

        // 開啟冠軍檔案的函式
        private void openWinnersFile()
        {
            try
            {
                // 顯示提示訊息，要求使用者選擇檔案
                MessageBox.Show("請選擇冠軍隊檔案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 建立 OpenFileDialog 物件
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "請選擇 WorldSeries_Chinese 檔案",
                    Filter = "文字檔案 (*.txt)|*.txt",
                    Multiselect = false // 僅允許選擇單一檔案
                };

                // 顯示對話框並檢查使用者是否選擇了檔案
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 取得選擇的檔案路徑
                    string filePath = openFileDialog.FileName;

                    // 檢查檔案名稱是否正確
                    if (filePath.Contains("WorldSeries_Chinese"))
                    {
                        // 清空冠軍清單
                        winner.Clear();
                        years.Clear();

                        // 讀取檔案內容並存入清單
                        using (StreamReader inputFile = new StreamReader(filePath))
                        {
                            int year = 1903; // 冠軍年份從 1903 年開始
                            while (!inputFile.EndOfStream)
                            {
                                string line = inputFile.ReadLine();
                                if (!string.IsNullOrWhiteSpace(line))
                                {
                                    winner.Add(line);
                                    years.Add(year);
                                }

                                // 跳過 1904 年和 1994 年，這兩年沒有舉行 MLB 冠軍賽
                                if (year == 1903) year += 2;
                                else if (year == 1993) year += 2;
                                else year++;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("請選擇正確的檔案：WorldSeries_Chinese。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit(); // 如果檔案不正確，關閉程式
                    }
                }
                else
                {
                    MessageBox.Show("未選擇檔案，程式即將結束。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit(); // 如果未選擇檔案，關閉程式
                }
            }
            catch (Exception ex)
            {
                // 如果發生錯誤，顯示錯誤訊息
                MessageBox.Show("開啟檔案時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // 如果發生錯誤，關閉程式
            }
        }

        // 當使用者選擇 ListBox 中的項目時執行的事件處理函式
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 取得使用者選擇的隊伍名稱
            string selectedTeam = listBox1.SelectedItem.ToString();

            // 找出該隊伍獲勝的年份
            List<int> winningYears = new List<int>();
            for (int i = 0; i < winner.Count; i++)
            {
                if (winner[i] == selectedTeam)
                {
                    winningYears.Add(years[i]);
                }
            }

            // 顯示該隊伍的得冠年份與總次數
            if (winningYears.Count > 0)
            {
                label1.Text = $"{selectedTeam} 總共贏得 {winningYears.Count} 次 MLB 冠軍，分別在以下年份：\n{string.Join(", ", winningYears)}";
            }
            else
            {
                label1.Text = $"{selectedTeam} 從未贏得 MLB 冠軍。";
            }
        }
    }
}
