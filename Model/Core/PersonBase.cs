using LotteryArchive.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public abstract class PersonBase : IPerson
    {
        private static int _lastId = 0;

        public int Id { get; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        protected PersonBase()
        {
            Id = Interlocked.Increment(ref _lastId);
        }

        public string Fullname => $"{Firstname} {Lastname}";
    }
}
