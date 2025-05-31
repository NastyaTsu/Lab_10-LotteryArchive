using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public partial class Lottery
    {
        public int Price {  get; private set; }
        public Ticket Buy(LotteryParticipant person)
        {
            return person.Buy(this);
        }
    }
}
