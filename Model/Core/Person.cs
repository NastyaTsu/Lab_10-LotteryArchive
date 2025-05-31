using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public class Person : IPerson
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Person(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
            _id++;
        }
        public string Fullname => $"{Firstname} {Lastname}";

        private static int _id = 0;
        public static int Id => _id; // количество участников

        public override string ToString()
        {
            return Fullname + Id;
        }
    }

}
