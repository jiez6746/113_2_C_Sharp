using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Toss
{
    /// <summary>
    /// 這個 coin 類別目前尚未實作任何功能。
    /// 可於未來擴充以模擬硬幣相關行為。
    /// </summary>
    internal class coin
    {
        private string sideup;// 硬幣的正面朝上
        Random rand = new Random();// 隨機數產生器
        public coin()
        {
          sideup = "正面";// 預設硬幣正面為 "正面"
        }
        public void Toss()
        {
            // 擲硬幣，隨機決定正面或反面
            Random rand = new Random();
            if (rand.Next (2) == 0)
            {
                sideup = "正面";
            }
            else
            {
                sideup = "反面";
            }
        }
        public string getSideUp()
        {
             // 回傳目前硬幣的正面朝上
             return sideup;
        }
     }
}
