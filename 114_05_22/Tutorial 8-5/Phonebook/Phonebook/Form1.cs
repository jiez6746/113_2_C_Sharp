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

namespace Phonebook
{
    // 結構：用來儲存電話簿的單一聯絡人資料（姓名與電話）
    struct PhoneBookEntry
    {
        public string name;   // 聯絡人姓名
        public string phone;  // 聯絡人電話
    }

    public partial class Form1 : Form
    {
        // 欄位：用來儲存所有聯絡人資料的清單
        private List<PhoneBookEntry> phoneList =
            new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        // 方法：讀取 PhoneList.txt 檔案內容，並將每一筆資料
        // 轉換為 PhoneBookEntry 物件後，存入 phoneList 清單中。
        // 檔案每一行應包含姓名與電話，格式為「姓名,電話」。
        private void ReadFile()
        {
            StreamReader inputFile;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {


                    inputFile = File.OpenText(openFile.FileName);
                    string line;
                    while (!inputFile.EndOfStream)
                    {
                        // 將每一行資料分割為姓名與電話
                        line = inputFile.ReadLine().Trim();
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            PhoneBookEntry entry;
                            entry.name = parts[0].Trim();
                            entry.phone = parts[1].Trim();
                            phoneList.Add(entry);
                        }
                        else
                        {
                            MessageBox.Show("資料格式錯誤，請檢查檔案內容。");
                        }
                    }
                    inputFile.Close();

                }
                catch (IOException ex)
                {
                    MessageBox.Show("檔案讀取錯誤：" + ex.Message);
                }
            }

        }

        // 方法：將 phoneList 清單中的所有聯絡人姓名
        // 顯示在 namesListBox 控制項上，方便使用者瀏覽。
        private void DisplayNames()
        {
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name);
            }
        }

        // 事件處理：當表單載入時執行
        // 通常用來初始化資料，例如讀取檔案並顯示聯絡人清單。
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();// 讀取檔案

            DisplayNames();// 顯示聯絡人姓名在 namesListBox 上
        }

        // 事件處理：當使用者在 nameListBox 選取不同聯絡人時執行
        // 可用來顯示該聯絡人的詳細資料（如電話號碼）。
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            if (index != -1)
            {
                phoneLabel.Text = phoneList[index].phone;

            }
            else
            {
                phoneLabel.Text = "無資料";
            }
        }

        // 事件處理：當使用者按下「離開」按鈕時執行
        // 關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單（結束程式）
            this.Close();
        }
    }
}
