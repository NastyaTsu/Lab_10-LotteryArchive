using LotteryArchive.Model.Core;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public abstract class Serializer : ISerializer
    {
        public abstract void SerializeLottery(Lottery lotter, WinningTicket TicetWin);

        public abstract List<string> DeserializeLottery(string file);
    }
}
