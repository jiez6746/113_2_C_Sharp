using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidNumber 方法接受一個字串作為參數。
        // 此方法會檢查該字串是否包含 10 個數字。
        // 如果字串包含 10 個數字，則回傳 true；否則回傳 false。
        private bool IsValidNumber(string str)
        {
            const int VALID_LENGTH = 10; // 定義有效的字串長度為 10。
            if (str.Length == VALID_LENGTH)
            {
                for (int i = 0; i < str.Length; i++)
                {
                return false;
                }
                return true;

            }
            return false;
        }

        // TelephoneFormat 方法接受一個字串參數 (以參考方式傳遞)。
        // 此方法會將該字串格式化為電話號碼的形式。
        // 格式化後的電話號碼通常為 (12) 3456-7890 的格式。
        // (12) 34567890
        private void TelephoneFormat(ref string str)
        {
            // if (str.Length == 10)
            //{ 
            //str = $"({str.Substring(0, 2)}) {str.Substring(2, 4)}-{str.Substring(6, 4)}";
            //}
            str = str.Insert(0, "(");// 在字串的開頭插入左括號。
            str = str.Insert(3, ") ");// 在字串的第 3 個位置插入右括號和空格。
            str = str.Insert(9,"-");// 在字串的第 9 個位置插入連字號。


        }

        // 當使用者按下「格式化」按鈕時，會觸發 formatButton_Click 事件。
        // 此方法會執行以下操作：
        // 1. 檢查使用者輸入的字串是否為有效的 10 位數字。
        // 2. 如果有效，則將字串格式化為電話號碼。
        // 3. 如果無效，則顯示錯誤訊息。
        private void formatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text; // 檢查輸入的字串是否為有效的 10 位數字。
           
            if (IsValidNumber( input))
            {
          
                TelephoneFormat(ref input);// 顯示格式化後的電話號碼。
                MessageBox.Show(input, "格式化結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // numberTextBox.Text = input;
            }
            else
            {
                // 如果無效，則顯示錯誤訊息。
                MessageBox.Show("請輸入有效的 10 位數字。" , "錯誤" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 當使用者按下「離開」按鈕時，會觸發 exitButton_Click 事件。
        // 此方法會關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
