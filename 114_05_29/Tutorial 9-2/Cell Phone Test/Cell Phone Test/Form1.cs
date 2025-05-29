using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData 方法會接收一個 CellPhone 物件作為參數。
        // 此方法預期將使用者輸入的資料指派給 CellPhone 物件的屬性。
        private void GetPhoneData(CellPhone phone)
        {
            decimal price;

            phone.Beand = brandTextBox.Text; // 將使用者輸入的品牌指派給 phone 物件的 Beand 屬性。
            phone.Model = modelTextBox.Text; // 將使用者輸入的型號指派給 phone 物件的 Model 屬性。

            // 嘗試將使用者輸入的價格轉換為 decimal 型別。
            if(decimal.TryParse(priceTextBox.Text, out price))
            {
                // 如果轉換成功，將價格指派給 phone 物件的 Price 屬性。
                phone.Price = price;
            }
            else
            {
                // 如果轉換失敗，顯示錯誤訊息並清除價格欄位。
                MessageBox.Show("請輸入有效的價格。" , "錯誤" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                priceTextBox.Clear();
            }
        }

        // 當使用者按下「建立物件」按鈕時執行此事件處理方法。
        // 此方法預期會建立 CellPhone 物件並顯示相關資料。
        private void createObjectButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhome = new CellPhone();// 建立 CellPhone 物件。並指派給 myPhome 變數。

            GetPhoneData(myPhome);// 呼叫 GetPhoneData 方法，將使用者輸入的資料指派給 myPhome 物件。

            //將 myPhome 物件的資料顯示在標籤中。
            brandLabel.Text = myPhome.Beand;
            modelLabel.Text = myPhome.Model;
            priceLabel.Text = myPhome.Price.ToString("C2");// 將價格格式化為貨幣格式並顯示。

        }

        // 當使用者按下「離開」按鈕時執行此事件處理方法。
        // 此方法會關閉目前的表單，結束程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束應用程式。
            this.Close();
        }
    }
}
