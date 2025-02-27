namespace Toturial4_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculatebutton_Click(object sender, EventArgs e)
        {
            double distance, gas, average; //宣告區域變數
            if (double.TryParse(distancetextbox.Text, out distance))
            {
                if (double.TryParse(gastextBox.Text, out gas))
                {
                    average = distance / gas; //計算平均值
                    averagelabel.Text = "平均油耗：" + average.ToString("f2") + "公里/公升"; //顯示平均油耗
                    loglistBox.Items.Add(average.ToString("f2") + "公里/公升"); //將平均油耗加入loglistBox
                }
                else
                {
                    MessageBox.Show("油耗請輸入數字");
                    gastextBox.Focus(); //將游標移至gastextBox
                    gastextBox.Text = ""; //清空gastextBox
                }
            }
            else
            {
                MessageBox.Show("里程請輸入數字");
                distancetextbox.Focus(); //將游標移至distancetextbox
                distancetextbox.Text = ""; //清空distancetextbox
            }
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Close(); //關閉視窗
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loglistBox.Items.Clear();
            loglistBox.Items.Add("平均油耗紀錄:");
        }

        private void button_Click(object sender, EventArgs e)
        {
            double sum = 0;
            if (loglistBox.Items.Count > 1)
            {
                loglistBox.Items.Add("平均油耗紀錄:");
                for (int i = 1; i < loglistBox.Items.Count; i++)
                {
                    sum += double.Parse(loglistBox.Items[i].ToString().Replace("公里/公升", "")); //將loglistBox的值轉換成double並加總

                }
                loglistBox.Items.Add("平均油耗紀錄"+(sum / (loglistBox.Items.Count - 1)).ToString("f2") + "公里/公升"); //顯示平均油耗總和
            }
            else
            {
                MessageBox.Show("沒有紀錄");
            }
        }
    }
}
