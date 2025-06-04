using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Person
{
    public abstract class PersonBase : IPerson
    {
        private static int _lastId = 0;

        public int Id { get; }
        public string Firstname { get; }
        public string Lastname { get; }

        protected PersonBase()
        {
            Id = Interlocked.Increment(ref _lastId);
        }

        public string Fullname => $"{Firstname} {Lastname}";
    }
}
