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
            double distance, gas, average; //�ŧi�ϰ��ܼ�
            if (double.TryParse(distancetextbox.Text, out distance))
            {
                if (double.TryParse(gastextBox.Text, out gas))
                {
                    average = distance / gas; //�p�⥭����
                    averagelabel.Text = "�����o�ӡG" + average.ToString("f2") + "����/����"; //��ܥ����o��
                    loglistBox.Items.Add(average.ToString("f2") + "����/����"); //�N�����o�ӥ[�JloglistBox
                }
                else
                {
                    MessageBox.Show("�o�ӽп�J�Ʀr");
                    gastextBox.Focus(); //�N��в���gastextBox
                    gastextBox.Text = ""; //�M��gastextBox
                }
            }
            else
            {
                MessageBox.Show("���{�п�J�Ʀr");
                distancetextbox.Focus(); //�N��в���distancetextbox
                distancetextbox.Text = ""; //�M��distancetextbox
            }
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Close(); //��������
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loglistBox.Items.Clear();
            loglistBox.Items.Add("�����o�Ӭ���:");
        }

        private void button_Click(object sender, EventArgs e)
        {
            double sum = 0;
            if (loglistBox.Items.Count > 1)
            {
                loglistBox.Items.Add("�����o�Ӭ���:");
                for (int i = 1; i < loglistBox.Items.Count; i++)
                {
                    sum += double.Parse(loglistBox.Items[i].ToString().Replace("����/����", "")); //�NloglistBox�����ഫ��double�å[�`

                }
                loglistBox.Items.Add("�����o�Ӭ���"+(sum / (loglistBox.Items.Count - 1)).ToString("f2") + "����/����"); //��ܥ����o���`�M
            }
            else
            {
                MessageBox.Show("�S������");
            }
        }
    }
}
