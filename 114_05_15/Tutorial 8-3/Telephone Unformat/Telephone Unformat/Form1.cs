using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidFormat 方法接受一個字串參數，並檢查該字串是否符合美國電話號碼的格式。
        // 格式要求如下：(XX)XXXX-XXXX
        // - (XX)：括號內包含兩位數字。
        // - XXXX：括號後接四位數字。
        // - -XXXX：最後接一個連字號和四位數字。
        // 如果字串符合上述格式，則方法回傳 true；否則回傳 false。
        private bool IsValidFormat(string str)
        {
            if (str.Length == 13 &&
                str[0] == '(' &&
                str[3] == ')' &&
                str[8] == '-') // 檢查字串長度是否為 13
            {
                string areaCode = str.Substring(1, 2);// 取得區域碼
                string firstPart = str.Substring(4, 4);// 取得第一部分
                string secondPart = str.Substring(9, 4);// 取得第二部分

                // 檢查區域碼和兩個部分是否都是數字
                if (IsAllDigit(areaCode) &&
                    IsAllDigit(firstPart) &&
                    IsAllDigit(secondPart))
                {
                    return true;// 如果符合格式，則回傳 true
                }
            }
            return false; // 如果不符合格式，則回傳 false
        }
            private bool IsAllDigit(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false;// 如果字串不符合格式，則回傳 false
                }
            }
            return true;// 如果字串都是數字，則回傳 true
        }
           


        // Unformat 方法接受一個字串參數（以參考方式傳遞），該字串假設為格式化的電話號碼。
        // 格式為：(XX)XXXX-XXXX
        // 此方法的功能是移除字串中的括號和連字號，將其轉換為未格式化的純數字字串。
        // 例如，輸入 "(12)3456-7890" 將被轉換為 "1234567890"。
        private void Unformat(ref string str)
        {
            str = str.Remove(0, 1)// 移除左括號 '('
                     .Remove(2, 1)// 移除右括號 ')'
                     .Remove(6, 1);// 移除連字號 '-'
        }

        // unformatButton_Click 方法是當使用者按下「去格式化」按鈕時觸發的事件處理程式。
        // 此方法的功能是：
        // 1. 取得使用者在文字框中輸入的電話號碼。
        // 2. 驗證電話號碼是否符合格式 (XX)XXXX-XXXX。
        // 3. 如果格式正確，則呼叫 Unformat 方法移除格式，並顯示未格式化的電話號碼。
        // 4. 如果格式不正確，則顯示錯誤訊息。
        private void unformatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;// 取得使用者輸入的電話號碼
            input = input.Trim();
            if (IsValidFormat(input))
            { 
            Unformat(ref input);// 呼叫 Unformat 方法移除格式
                MessageBox.Show("去格式化的電話號碼是：" + input , "結果" , MessageBoxButtons.OK,MessageBoxIcon.Information);// 顯示未格式化的電話號碼
            }
            else
            {
                MessageBox.Show("請輸入正確的電話號碼格式!" , "錯誤" , MessageBoxButtons.OK,MessageBoxIcon.Information);// 顯示錯誤訊息
                // 清空文字框
                numberTextBox.Text = "";// 清空文字框
                numberTextBox.Focus();// 將焦點設置在文字框上
            }

        }

        // exitButton_Click 方法是當使用者按下「離開」按鈕時觸發的事件處理程式。
        // 此方法的功能是關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
