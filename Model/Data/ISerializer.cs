using LotteryArchive.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public interface ISerializer
    {
        abstract void SerializeLottery(Lottery lotter, WinningTicket TicetWin);
        abstract List<string> DeserializeLottery(string file);
    }
}
