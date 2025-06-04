using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Core.Person;

namespace LotteryArchive.Model.Core
{
    public class Person : IPerson
    {
        private string _name;
        private string _lastname;
        public string Firstname => _name;
        public string Lastname => _lastname;
        public int Id { get; } // Уникальный ID для каждого участника
        private static int _lastId = 0;

        public Person(string firstname, string lastname)
        {
            Id = Interlocked.Increment(ref _lastId);
            _name = firstname;
            _lastname = lastname;
        }
        public Person() { }
        public string Fullname => $"{Firstname} {Lastname}";
        public void First(string firstName)
        {
            _name = firstName;
        }
        public void Last(string lastName)
        {
            _lastname = lastName;
        }

        public override string ToString()
        {
            return Fullname + Id;
        }
    }

}
