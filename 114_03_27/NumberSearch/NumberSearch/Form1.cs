namespace NumberSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int SIZE = 1000;
            int num;
            double frequency;
            Random random = new Random();
            int[] number = new int[1000];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = random.Next(1, 101);
            }

            if (int.TryParse(numbertextBox.Text, out num))
            {
                frequency = (double)frequencyOfNnumber(number, num) / SIZE;
                MessageBox.Show("數字" + num + "出現的機率為:" + frequency.ToString("P"));
            }
            else
            {
                MessageBox.Show("型態錯誤:請輸入整數!");
            }
        }

        private int frequencyOfNnumber(int[] number, int num)
        {
            int count = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == num)
                {
                    count++;
                }
            }
            return count;
        }
    }
















    
}
