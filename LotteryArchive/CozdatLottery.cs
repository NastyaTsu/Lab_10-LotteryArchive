using LotteryArchive.Model.Core;
using LotteryArchive.Model;
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
using static LotteryArchive.Model.Core.LotteryParticipant;

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
            if (Participant.People.Count < KolPerson)
            {
                MessageBox.Show($"Недостаточно участников. Требуется: {KolPerson}, доступно: {Participant.People.Count}");
                return;
            }
            var selectedParticipants = GetRandomParticipants(KolPerson);

            // Проверяем баланс участников
            foreach (var participant in selectedParticipants)
            {
                if (participant.Balance < KolPrice)
                {
                    MessageBox.Show($"У участника {participant.Fullname} недостаточно средств");
                    return;
                }
            }

            // Списываем средства за участие
            foreach (var participant in selectedParticipants)
            {
                participant.MinToBalance(KolPrice);
            }

            
            var lottery = new Lottery(name, KolBilet, KolPrize, KolPerson, KolPrice);
            var tic = new Ticket();
            tic.SetCost(lottery);
            lottery.DistributeTickets(selectedParticipants);
            var TicetWin = lottery.DetermineWinner();
            if (TicetWin == null)
            {
                MessageBox.Show("Лотерея отменена");
                return;
            }

            // Начисляем выигрыш победителю
            LotteryParticipant lotteryParticipant1 = TicetWin.Owner as LotteryParticipant;

            lotteryParticipant1.AddToBalance(KolPrize);
            string id = TicetWin.Id;
            LotteryParticipant person = TicetWin.Owner;
            string FullNamePerson = person.Fullname;
            int PersonBalanse = person.Balance;

            MessageBox.Show($"Победитель: {FullNamePerson}{Environment.NewLine} id выигрышного билета: {id}{Environment.NewLine} Выигрыш: {KolPrize}{Environment.NewLine} Баланс победителя {PersonBalanse}");


            if (LotteryMain.SelectedItem == "Json")
            {
                new JsonSerializer().SerializeLottery(lottery, TicetWin);
            }
            if (LotteryMain.SelectedItem == "Xml")
            {
                new XmlSerializer().SerializeLottery(lottery, TicetWin);
            }

        }
        private List<LotteryParticipant> GetRandomParticipants(int count)
        {
            var random = new Random();
            // Создаем копию списка участников
            var availableParticipants = new List<LotteryParticipant>(Participant.People);
            var selectedParticipants = new List<LotteryParticipant>();

            // Выбираем случайных участников
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(availableParticipants.Count);
                selectedParticipants.Add(availableParticipants[index]);
                availableParticipants.RemoveAt(index); // Удаляем, чтобы не выбирать повторно
            }

            return selectedParticipants;
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

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
        private void CozdatLottery_Load(object sender, EventArgs e) { }
    }
}
