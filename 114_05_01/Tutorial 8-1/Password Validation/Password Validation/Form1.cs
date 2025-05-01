using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // NumberUpperCase 方法接受一個字串作為參數，
        // 並回傳該字串中包含的大寫字母數量。
        private int NumberUpperCase(string str)
        {
            int upperCaseCount = 0; // 計數器，初始值為 0
            foreach (char c in str)
            {
                if (char.IsUpper(c))
                { 
                upperCaseCount++; // 如果字元是大寫字母，計數器加 1
                }
            }
            return upperCaseCount; // 回傳大寫字母的數量
        }

        // NumberLowerCase 方法接受一個字串作為參數，
        // 並回傳該字串中包含的小寫字母數量。
        private int NumberLowerCase(string str)
        {
            int lowerCaseCount = 0; // 計數器，初始值為 0
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLower(c))
                { 
                lowerCaseCount++; // 如果字元是小寫字母，計數器加 1
                }
                
            }
            return lowerCaseCount; // 回傳小寫字母的數量
        }

        // NumberDigits 方法接受一個字串作為參數，
        // 並回傳該字串中包含的數字字元數量。
        private int NumberDigits(string str)
        {

        }

        // 當使用者按下「檢查密碼」按鈕時，觸發此事件處理方法。
        // 此方法應該檢查使用者輸入的密碼是否符合規範，
        // 包括是否包含至少一個大寫字母、一個小寫字母和一個數字，
        // 並且密碼長度是否符合要求。
        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            const int MIN_LENGTH = 8; // 密碼的最小長度
            string password = passwordTextBox.Text; // 取得使用者輸入的密碼
            if (password.Length >= MIN_LENGTH &&
                NumberLowerCase(password) > 0 &&
                NumberUpperCase(password) > 0 &&
                NumberDigits(password) > 0)
            { 
            MessageBox.Show("密碼有效。", "驗證結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("密碼無效!" , "密碼檢查結果", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        // 當使用者按下「退出」按鈕時，觸發此事件處理方法。
        // 此方法會關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
