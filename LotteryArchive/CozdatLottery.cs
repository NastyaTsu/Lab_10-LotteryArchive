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
            string documentesPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
            //if (files.Length < numericUpDown1.Value)
            //{
            //    MessageBox.Show("Добавте больше участников");
            //    return;
            //}
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
            string item = $"Название лотереи: {name}, Количество участников: {KolPerson}, Количество билетов: {KolBilet}, Призовой фонд: {KolPrize}, Стоимость билета: {KolPrice}, Имя Победителя: {FullNamePerson}, Id победителя:{id}";
            MessageBox.Show($"Победитель: {FullNamePerson}{Environment.NewLine} id выигрышного билета: {id}{Environment.NewLine} Выигрыш: {KolPrize}{Environment.NewLine} Баланс победителя {PersonBalanse}");
            string fileName = $"{lottery.Name}_{DateTime.Now:yyyyMMddHHmmss}.json";
            string filePath = Path.Combine(documentesPath, fileName);
            if (Form1.SelectedItem == "Json")
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(item, filePath);
            }
            if (Form1.SelectedItem == "Xml")
            {
                XmlSerializer serializer = new XmlSerializer(item.GetType());
                serializer.Serialize(item, filePath);
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
    }
}
