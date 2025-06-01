using LotteryArchive.Model.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Model;
using Model.Data;
using JsonSerializer = Model.Data.JsonSerializer;
using XmlLotterySerializer = Model.Data.XmlSerializer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Data;

namespace LotteryArchive
{
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
            LoadData();

        }

        private void Statistic_Load(object sender, EventArgs e)
        {
        }


        private void LoadData()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "Статистика");

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Статистика отсутствует.");
                return;
            }

            string[] files = Directory.GetFiles(folderPath, "*.json")
                .Concat(Directory.GetFiles(folderPath, "*.xml"))
                .ToArray();

            if (files.Length == 0)
            {
                MessageBox.Show("Файлы статистики не найдены.");
                return;
            }
            var table = new DataTable();

            // Создаём колонки, соответствующие полям JSON
            table.Columns.Add("Название лотереи", typeof(string));
            table.Columns.Add("Количество участников", typeof(int));
            table.Columns.Add("Количество билетов", typeof(int));
            table.Columns.Add("Призовой фонд", typeof(decimal));
            table.Columns.Add("Цена билета", typeof(decimal));
            table.Columns.Add("Победитель", typeof(string));
            table.Columns.Add("ID победителя", typeof(string));
            table.Columns.Add("Дата проведения", typeof(DateTime));

            foreach (var file in files)
            {
                List<string> result;

                string extension = Path.GetExtension(file).ToLower();

                if (extension == ".json")
                {
                    result = new JsonSerializer().DeserializeLottery(file); // ваш метод для JSON
                }
                else if (extension == ".xml")
                {
                    result = new XmlLotterySerializer().DeserializeLottery(file); // ваш метод для XML
                }
                else
                {
                    continue;
                }

                if (result == null || result.Count < 8)
                    continue; // Проверка на корректность данных

                string lotteryName = result[0];
                string participants = result[1];
                string tickets = result[2];
                string prizeFund = result[3];
                string ticketPrice = result[4];
                string winner = result[5];
                string winnerId = result[6];
                string date = result[7];

                table.Rows.Add(lotteryName, participants, tickets, prizeFund, ticketPrice, winner, winnerId, date);
            }


            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
