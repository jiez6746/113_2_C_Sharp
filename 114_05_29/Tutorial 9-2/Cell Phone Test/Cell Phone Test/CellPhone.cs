using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Test
{
    // CellPhone 類別用來表示手機的基本資訊。
    // 此類別包含三個私有欄位：品牌、型號與價格。
    class CellPhone
    {
        // 儲存手機品牌的欄位。
        private string beand;
        // 儲存手機型號的欄位。
        private string model;
        // 儲存手機價格的欄位。
        private decimal price;

        public CellPhone()
        {
            beand = "";
            model = "";
            price = 0m;
        }
        public string Beand
        {
            get
            { return beand; }
            set
            { beand = value; }
           
        }

        public string Model
        {
            get
            { return model; }
            set
            { model = value; }
        }

        public decimal Price
        {
            get
            { return price; }
            set
            { 
            if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
                }
                price = value;

             }
        }
    }
}
