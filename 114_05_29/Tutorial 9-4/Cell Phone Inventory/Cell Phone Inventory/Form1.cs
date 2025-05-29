using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 用來儲存 CellPhone 物件的清單
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取得使用者輸入的手機資料，並指派給傳入的 CellPhone 物件屬性。
        /// </summary>
        /// <param name="phone">要指派資料的 CellPhone 物件</param>
        private void GetPhoneData(CellPhone phone)
        {
            // 暫存手機價格的變數
            decimal price;

            // 取得使用者輸入的品牌，並指派給 CellPhone 物件的 Brand 屬性
            phone.Brand = brandTextBox.Text;

            // 取得使用者輸入的型號，並指派給 CellPhone 物件的 Model 屬性
            phone.Model = modelTextBox.Text;

            // 取得使用者輸入的價格，並嘗試轉換為 decimal 型別
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                // 若轉換成功，將價格指派給 CellPhone 物件的 Price 屬性
                phone.Price = price;
            }
            else
            {
                // 若轉換失敗，顯示錯誤訊息提示使用者價格格式錯誤
                MessageBox.Show("價格格式無效，請輸入正確的數字。");
            }
        }

        /// <summary>
        /// 當使用者點擊「新增手機」按鈕時觸發的事件處理方法。
        /// </summary>
        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone(); // 建立新的 CellPhone 物件

            GetPhoneData(myPhone); // 取得使用者輸入的手機資料

            // 將新的手機物件加入到手機清單中
            phoneList.Add(myPhone);

            // 將新的手機物件的品牌和型號組合成字串，並加入到 ListBox 中
            phoneListBox.Items.Add(myPhone.Brand + " " + myPhone.Model);

            // 清空輸入欄位，準備下一次輸入
            brandTextBox.Text = "";
            modelTextBox.Text = "";
            priceTextBox.Text = "";

        }

        /// <summary>
        /// 當使用者在手機清單中選取不同項目時觸發的事件處理方法。
        /// </summary>
        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = phoneListBox.SelectedIndex;// 取得選取的項目索引

            MessageBox.Show(phoneList[index].Price.ToString("C"));
           
            // 顯示選取手機的價格，格式化為貨幣形式
        }
            /// <summary>
            /// 當使用者點擊「離開」按鈕時觸發，關閉視窗。
            /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束程式
            this.Close();
        }
    }
}
