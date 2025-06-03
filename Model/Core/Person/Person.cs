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
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Id { get; } // Уникальный ID для каждого участника
        private static int _lastId = 0;

        public Person(string firstname, string lastname)
        {
            Id = Interlocked.Increment(ref _lastId);
            Firstname = firstname;
            Lastname = lastname;
        }
        public string Fullname => $"{Firstname} {Lastname}";

        public override string ToString()
        {
            return Fullname + Id;
        }
    }

}
