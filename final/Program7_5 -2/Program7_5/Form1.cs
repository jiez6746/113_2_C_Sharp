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

        private string teamsFilePath = "";
        private string worldSeriesFilePath = "";

        // 當表單載入時執行的事件處理函式  
        private void Form1_Load(object sender, EventArgs e)
        {
            openTeamsFile();
            openWinnersFile();
        }

        // 開啟隊伍檔案的函式  
        private void openTeamsFile()
        {
            try
            {
                MessageBox.Show("請選擇球隊檔案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "請選擇 MLB_Teams_Translated 檔案",
                    Filter = "文字檔案 (*.txt)|*.txt",
                    Multiselect = false
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    if (filePath.Contains("MLB_Teams_Translated"))
                    {
                        teamsFilePath = filePath;
                        team.Clear();
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
                        listBox1.Items.Clear();
                        listBox1.Items.AddRange(team.ToArray());
                    }
                    else
                    {
                        MessageBox.Show("請選擇正確的檔案：MLB_Teams_Translated。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("未選擇檔案，程式即將結束。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("開啟檔案時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // 開啟冠軍檔案的函式  
        private void openWinnersFile()
        {
            try
            {
                MessageBox.Show("請選擇冠軍隊檔案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "請選擇 WorldSeries_Chinese 檔案",
                    Filter = "文字檔案 (*.txt)|*.txt",
                    Multiselect = false
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    if (filePath.Contains("WorldSeries_Chinese"))
                    {
                        worldSeriesFilePath = filePath;
                        winner.Clear();
                        years.Clear();
                        using (StreamReader inputFile = new StreamReader(filePath))
                        {
                            int year = 1903;
                            while (!inputFile.EndOfStream && year <= 2024)
                            {
                                string line = inputFile.ReadLine();
                                if (!string.IsNullOrWhiteSpace(line))
                                {
                                    winner.Add(line);
                                    years.Add(year);
                                }
                                if (year == 1903) year += 2;
                                else if (year == 1993) year += 2;
                                else year++;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("請選擇正確的檔案：WorldSeries_Chinese。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("未選擇檔案，程式即將結束。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("開啟檔案時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // 當使用者選擇 ListBox 中的項目時執行的事件處理函式  
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTeam = listBox1.SelectedItem.ToString();

            List<int> winningYears = new List<int>();
            for (int i = 0; i < winner.Count; i++)
            {
                if (winner[i] == selectedTeam)
                {
                    winningYears.Add(years[i]);
                }
            }

            if (winningYears.Count > 0)
            {
                label1.Text = $"{selectedTeam} 總共贏得 {winningYears.Count} 次 MLB 冠軍，分別在以下年份：\n{string.Join(", ", winningYears)}";
            }
            else
            {
                label1.Text = $"{selectedTeam} 從未贏得 MLB 冠軍。";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請選擇要新增的檔案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "請選擇 WorldSeries_2010_2024_Chinese 檔案",
                Filter = "文字檔案 (*.txt)|*.txt",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                if (!filePath.Contains("WorldSeries_2010_2024_Chinese"))
                {
                    MessageBox.Show("請選擇正確的檔案：WorldSeries_2010_2024_Chinese。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<string> newWinners = new List<string>();
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(line))
                            newWinners.Add(line);
                    }
                }

                // 取得目前 winner 最後一個年份，若沒有則從 2010 開始
                int startYear = years.Count > 0 ? years.Max() + 1 : 2010;

                for (int i = 0; i < newWinners.Count; i++)
                {
                    winner.Add(newWinners[i]);
                    years.Add(startYear + i);
                }

                // 只加入新隊伍
                var addedTeams = newWinners.Where(nw => !team.Contains(nw)).Distinct().ToList();
                team.AddRange(addedTeams);

                listBox1.Items.Clear();
                listBox1.Items.AddRange(team.ToArray());

                MessageBox.Show("新增完成，隊伍已更新於清單。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 自動選取剛新增的第一個隊伍，顯示其勝利年分與次數
                if (addedTeams.Count > 0)
                {
                    int idx = team.IndexOf(addedTeams[0]);
                    if (idx >= 0)
                        listBox1.SelectedIndex = idx;
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            try
            {
                // 寫入 MLB_Teams_Translated（新增隊伍在檔案末端）
                if (!string.IsNullOrEmpty(teamsFilePath))
                    File.WriteAllLines(teamsFilePath, team, Encoding.UTF8);

                // 寫入 WorldSeries_Chinese（新增冠軍在檔案末端）
                if (!string.IsNullOrEmpty(worldSeriesFilePath))
                    File.WriteAllLines(worldSeriesFilePath, winner, Encoding.UTF8);

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存檔案時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void DisplayYearAndWins()
        {
            StringBuilder result = new StringBuilder();
            var groupedWinners = winner.GroupBy(w => w)
                                       .Select(g => new { Team = g.Key, Wins = g.Count() })
                                       .OrderByDescending(t => t.Wins);

            result.AppendLine("隊伍得冠總次數：");
            foreach (var team in groupedWinners)
            {
                result.AppendLine($"{team.Team}: {team.Wins} 次");
            }

            result.AppendLine("\n年份與冠軍隊伍：");
            for (int i = 0; i < years.Count; i++)
            {
                result.AppendLine($"{years[i]}: {winner[i]}");
            }

            MessageBox.Show(result.ToString(), "冠軍資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

       

       

        // 修正後的程式碼，移除無效的程式碼片段  
        // 並確保程式碼在正確的範圍內執行  

       }
}
