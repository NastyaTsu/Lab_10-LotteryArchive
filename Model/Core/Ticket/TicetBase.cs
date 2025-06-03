using LotteryArchive.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Ticket
{
    public abstract class TicetBase
    {
        public abstract string Id { get; }
        public abstract LotteryParticipant Owner { get; }
        public abstract int Cost { get; }
    }
}
