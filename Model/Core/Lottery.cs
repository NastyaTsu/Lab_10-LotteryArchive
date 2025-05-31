using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public partial class Lottery
    {
        
        public string Name { get; set; }
        public int Totaltickets { get; set; }
        public int Prizefond { get; set; }
        public int Colparticipants { get; set; }
        private List<Ticket> _ticket;
        public List<Ticket> Massivticket
        {
            get
            {
                List<Ticket> list = new List<Ticket>();
                foreach (var ticket in _ticket)
                {
                    list.Add(ticket);
                }
                return list;
            }
        }

        private List<LotteryParticipant> _person;
        public Lottery(string name, int totaltickets, int prizefond, int colparticipants, int price)
        {
            Name = name;
            Totaltickets = totaltickets;
            Prizefond = prizefond;
            Colparticipants = colparticipants;
            _ticket = new List<Ticket>(Totaltickets);
            Price = price;
        }
        public void RandomPerson()
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

            Random random = new Random();
            for (int i = 0; i < Totaltickets; i++)
            {
                int randomBalanse = random.Next(1000);
                int randomzhadnost = random.Next(100);
                string randomFirstName = firstNames[random.Next(firstNames.Length)];
                string randomLastName = lastNames[random.Next(lastNames.Length)];
                var participaint = new LotteryParticipant(randomFirstName, randomLastName, randomBalanse, randomzhadnost);
                var byeticets = participaint.Buy(this);
                _ticket.Add(byeticets);
            }
            
        }
    }
}
