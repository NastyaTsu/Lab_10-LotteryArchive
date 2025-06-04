using LotteryArchive.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LotteryArchive
{
    public partial class Participant : Form
    {
        public static List<LotteryParticipant> People { get; set; } = new List<LotteryParticipant>();

        public Participant()
        {
            InitializeComponent();
        }
        public static event Action ParticipantsChanged;
        public static void AddParticipant(LotteryParticipant participant)
        {
            People.Add(participant);
            ParticipantsChanged?.Invoke();
        }

        // И в button1_Click:
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new PersonAddEdit();
            if (form.ShowDialog() == DialogResult.OK)
            {
                AddParticipant(form.Person); // Используем метод вместо People.Add
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = People;
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Проверяем, что выбрана строка
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите участника для редактирования");
                return;
            }

            // Получаем выбранного участника
            var selectedPerson = (LotteryParticipant)dataGridView1.SelectedRows[0].DataBoundItem;

            // Создаем форму редактирования
            var editForm = new PersonAddEdit(selectedPerson);

            // Открываем форму и проверяем результат
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Обновляем данные участника
                LotteryParticipant lotteryParticipant = selectedPerson as LotteryParticipant;
                lotteryParticipant.First(editForm.Person.Firstname);
                lotteryParticipant.Last(editForm.Person.Lastname);
                lotteryParticipant.NewZhadnost((int)editForm.Person.Zhadnost);
                lotteryParticipant.NewBalance((int)editForm.Person.Balance);


                // Обновляем отображение таблицы
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = People;
                MessageBox.Show("Данные участника обновлены");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить всех участников?",
                                        "Подтверждение удаления",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Participant.People.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = People;
                MessageBox.Show("Все участники удалены");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] firstNames = {
                "Александр", "Дмитрий", "Максим", "Сергей", "Андрей",
                "Алексей", "Артем", "Илья", "Кирилл", "Михаил",
                "Никита", "Матвей", "Роман", "Егор", "Арсений",
                "Иван", "Денис", "Евгений", "Даниил", "Тимофей",
                "Владислав", "Игорь", "Владимир", "Павел", "Руслан",
                "Марк", "Константин", "Тимур", "Олег", "Ярослав",
                "Анна", "Мария", "Елена", "Дарья", "Алина",
                "Ирина", "Екатерина", "Арина", "Наталья", "Виктория",
                "Ольга", "Юлия", "Татьяна", "Евгения", "Анастасия",
                "Полина", "Ксения", "София", "Александра", "Вероника"};
            string[] lastNames = {
                "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев",
                "Петров", "Соколов", "Михайлов", "Новиков", "Федоров",
                "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов",
                "Егоров", "Павлов", "Козлов", "Степанов", "Николаев",
                "Орлов", "Андреев", "Макаров", "Никитин", "Захаров",
                "Зайцев", "Соловьев", "Борисов", "Яковлев", "Григорьев",
                "Романов", "Воробьев", "Сергеев", "Кузьмин", "Фролов",
                "Александров", "Дмитриев", "Королев", "Гусев", "Киселев",
                "Ильин", "Максимов", "Поляков", "Сорокин", "Виноградов",
                "Ковалев", "Белов", "Медведев", "Антонов", "Тарасов" };

            Random rnd = new Random();

            // Генерируем 10 случайных людей
            for (int i = 0; i < 10; i++)
            {
                string lastName = lastNames[rnd.Next(lastNames.Length)];
                string firstName = firstNames[rnd.Next(firstNames.Length)];

                string fullName = $"{lastName} {firstName}";
                int greed = rnd.Next(1, 101); // Жадность от 1 до 100
                int balance = rnd.Next(100, 10001); // Баланс от 100 до 10000

                Participant.People.Add(new LotteryParticipant(firstName, lastName, balance, greed));
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = People;
            MessageBox.Show("Добавлено 10 случайных участников");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void Participant_Load(object sender, EventArgs e) { }
    }
}
