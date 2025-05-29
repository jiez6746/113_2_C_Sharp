using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coin_Toss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 當使用者點擊「擲硬幣五次」按鈕時觸發此事件處理函式。
        /// 此方法將會執行擲硬幣五次的邏輯，並將每次結果顯示於清單方塊中。
        /// </summary>
        private void tossButton_Click(object sender, EventArgs e)
        {
            coin myCoin = new coin(); // 建立一個 coin 類別的實例
            outputListBox.Items.Clear(); // 清除清單方塊中的舊有結果

            //
            for(int i = 1; i <= 5; i++)
            {
                myCoin.Toss(); // 擲硬幣
                string result = myCoin.getSideUp(); // 取得擲硬幣的結果
                outputListBox.Items.Add(myCoin.getSideUp()); // 將結果加入清單方塊
            }

            // 清除清單方塊中的舊有結果
            outputListBox.Items.Clear();

            // 建立隨機數產生器
            Random rand = new Random();

            // 進行五次擲硬幣
            for (int i = 1; i <= 5; i++)
            {
                // 產生 0 或 1，0 代表正面，1 代表反面
                int toss = rand.Next(2);
                string result = toss == 0 ? "正面" : "反面";
                // 將結果加入清單方塊，顯示第幾次及結果
                outputListBox.Items.Add($"第 {i} 次：{result}");
            }
        }

        /// <summary>
        /// 當使用者點擊「離開」按鈕時觸發此事件處理函式。
        /// 此方法會關閉目前的表單，結束應用程式。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的表單，結束程式執行
            this.Close();
        }
    }
}
