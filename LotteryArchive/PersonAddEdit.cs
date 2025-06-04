using LotteryArchive.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryArchive
{
    public partial class PersonAddEdit : Form
    {
        public PersonAddEdit()
        {
            InitializeComponent();
            Text = "Добавить человека";
        }
        public LotteryParticipant Person { get; private set; }
        private void PersonAddEdit_Load(object sender, EventArgs e) { }
        public PersonAddEdit(LotteryParticipant person) : this()
        {
            Text = "Редактировать человека";
            Person = person;
            textBox1.Text = person.Firstname;
            textBox2.Text = person.Lastname;
            numericUpDown2.Value = person.Zhadnost;
            numericUpDown1.Value = person.Balance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите Фамилию");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите Имя");
                return;
            }

            if (Person == null)
            {
                Person = new LotteryParticipant(
                    textBox1.Text,
                    textBox2.Text,
                    (int)numericUpDown1.Value,
                    (int)numericUpDown2.Value);
            }
            else
            {
                LotteryParticipant lotteryParticipant = Person as LotteryParticipant;
                lotteryParticipant.First(textBox1.Text);
                lotteryParticipant.Last(textBox2.Text);
                lotteryParticipant.NewBalance((int)numericUpDown1.Value);
                lotteryParticipant.NewZhadnost((int)numericUpDown2.Value);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}
