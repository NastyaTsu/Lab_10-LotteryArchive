using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public partial class Ticket
    {
        private int _id;
        private int _lenght;
        private LotteryParticipant _owner;
        public LotteryParticipant Owner => _owner;

        public string Id => _id.ToString($"D{_lenght}");
        public Ticket(Lottery lottery, LotteryParticipant person)
        {
            _id = person.Id;
            _owner = person;
            _lenght = lottery.Totaltickets.ToString().Length;
        }
        public Ticket()
        {

        }
        
    }
}
