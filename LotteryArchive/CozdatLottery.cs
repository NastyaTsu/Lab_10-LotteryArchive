using LotteryArchive.Model.Core;
using LotteryArchive.Model.Data;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Model.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LotteryArchive
{
    public partial class CozdatLottery : Form
    {
        public CozdatLottery()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Укажите название");
                return;

            }
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Количество участников должно быть больше нуля");
                return;
            }
            if (numericUpDown2.Value == 0)
            {
                MessageBox.Show("Количество билетов должно быть больше нуля");
                return;
            }
            if (numericUpDown3.Value == 0)
            {
                MessageBox.Show("Призовой фонд должен быть больше нуля");
                return;
            }
            if (numericUpDown2.Value < numericUpDown1.Value)
            {
                MessageBox.Show("Билетов должно быть больше или равно количеству участников");
                return;
            }
            if (numericUpDown4.Value == 0)
            {
                MessageBox.Show("Цена билета должена быть больше нуля");
                return;
            }
            //обработка победителя
            string name = textBox1.Text;
            int KolPerson = (int)numericUpDown1.Value;
            int KolBilet = (int)numericUpDown2.Value;
            int KolPrize = (int)numericUpDown3.Value;
            int KolPrice = (int)numericUpDown4.Value;

            var lottery = new Lottery(name, KolBilet, KolPrize, KolPerson, KolPrice);
            lottery.RandomPerson();
            var TicetWin = lottery.DetermineWinner();
            if (TicetWin == null)
            {
                MessageBox.Show("Лотерея отменена");
                return;
            }
            string id = TicetWin.Id;
            LotteryParticipant person = TicetWin.Owner;
            string FullNamePerson = person.Fullname;
            int PersonBalanse = person.Balance;

            MessageBox.Show($"Победитель: {FullNamePerson}{Environment.NewLine} id выигрышного билета: {id}{Environment.NewLine} Выигрыш: {KolPrize}{Environment.NewLine} Баланс победителя {PersonBalanse}");


            if (Form1.SelectedItem == "Json")
            {
                new JsonSerializer().SerializeLottery(lottery, TicetWin);
            }
            if (Form1.SelectedItem == "Xml")
            {
                //string fileName = $"{lottery.Name}_{DateTime.Now:yyyyMMddHHmmss}.xml";
                //string filePath = Path.Combine(newFolderPath, fileName);
                //XmlSerializer serializer = new XmlSerializer(result.GetType());
                //serializer.Serialize(result, filePath);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CozdatLottery_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lotteryNames = new string[] { "Золотая Лотерея", "Счастливый Билет", "Лотерея Удачи", "Везучий Джекпот", "Супер Лото",
                "Миллионер Экспресс", "Лотерея Мечты", "Быстрый Выигрыш", "Звездный Джекпот", "Секрет Удачи", "Фортуна Плюс", "Счастливый Шанс", 
                "Лото Премиум", "Большой Выигрыш", "Золотой Билет", "Экспресс Удачи", "Лотерея Сокровищ", "Джекпот Мания", "Супер Фортуна", 
                "Миллионный Шанс", "Волшебный Билет", "Лотерея Успеха", "Золотой Джекпот", "Счастливый Круг", "Лото Экспресс", "Мега Выигрыш", 
                "Фортуна Экспресс", "Супер Выигрыш", "Звездный Шанс", "Лотерея Мира", "Победитель Сегодня", "Счастливый Ключ", "Лотерея Счастья", 
                "Золотая Мечта", "Везение Плюс", "Джекпот Лидер", "Супер Билет", "Миллионер Плюс", "Лото Удачи", "Звездный Выигрыш", 
                "Фортуна Джекпот", "Лотерея Подарков", "Везучий Капитал", "Счастливый Момент", "Большой Джекпот", "Золотая Фортуна","Лото Мечты", 
                "Экспресс Победы", "Джекпот Удачи", "Супер Момент" };
            Random rnd = new Random();
            string randomLottery = lotteryNames[rnd.Next(lotteryNames.Length)];
            textBox1.Text = randomLottery;
        }
    }
}
