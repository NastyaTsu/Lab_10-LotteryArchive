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
        abstract void SerializeLottery<T>(T lotter, WinningTicket TicetWin) where T : Lottery;
        abstract List<string> DeserializeLottery(string file);
    }
}
