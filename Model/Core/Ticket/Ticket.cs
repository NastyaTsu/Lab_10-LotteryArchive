using Model.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public partial class Ticket : TicetBase
    {
        public override string Id => _id.ToString($"D{_lenght}");
        private LotteryParticipant _owner;
        public override LotteryParticipant Owner => _owner;
        private int _id;
        private int _lenght;
        public Ticket(Lottery lottery, LotteryParticipant person)
        {
            _id = person.Id;
            _owner = person;
            _lenght = lottery.Totaltickets.ToString().Length;
        }
        public Ticket()
        {

        }
        public override bool Equals(object obj)
        {
            if (obj is Ticket other)
                return this.Id == other.Id;
            return false;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
