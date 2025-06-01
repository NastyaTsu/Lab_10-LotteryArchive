using LotteryArchive.Model.Core;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public abstract class Serializer
    {
        public abstract void SerializeLottery(Lottery lotter, WinningTicket TicetWin);
        public abstract void SerializeParticipant(LotteryParticipant participant);

        public abstract List<string> DeserializeLottery(string file);
        public abstract LotteryParticipant DeserializeParticipant(string fileName);
    }
}
