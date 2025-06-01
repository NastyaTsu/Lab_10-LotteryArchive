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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace LotteryArchive
{
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            dynamic result = new JsonSerializer().DeserializeLottery();
            dataGridView1.Rows.Add(
                (string)result.Название_лотереи,
                ((int)result.Количество_участников).ToString(),
                ((int)result.Количество_билетов).ToString(),
                ((decimal)result.Призовой_фонд).ToString("C"),
                ((decimal)result.Цена_билета).ToString("C"),
                (string)result.Победитель,
                ((int)result.ID_победителя).ToString(),
                ((DateTime)result.Дата_проведения).ToShortDateString()
            );
        }
    }
}
