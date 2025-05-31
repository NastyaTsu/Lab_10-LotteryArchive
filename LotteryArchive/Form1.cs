using Model;
namespace LotteryArchive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static string _selectedItem;
        public static string SelectedItem => _selectedItem;

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form open in Application.OpenForms)
            {
                if (open is CozdatLottery)
                {
                    open.Focus();
                    return;
                }
            }
            CozdatLottery obj = new CozdatLottery();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Form open in Application.OpenForms)
            {
                if (open is Participant)
                {
                    open.Focus();
                    return;
                }
            }
            Participant obj = new Participant();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Form open in Application.OpenForms)
            {
                if (open is Statistic)
                {
                    open.Focus();
                    return;
                }
            }
            Statistic obj = new Statistic();
            obj.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedItem = comboBox1.SelectedItem.ToString();
        }
    }
}
