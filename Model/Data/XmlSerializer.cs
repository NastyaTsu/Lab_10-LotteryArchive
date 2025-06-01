using LotteryArchive.Model.Core;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LotteryArchive.Model.Data
{
    public class XmlSerializer : Serializer
    {

        public override List<dynamic> DeserializeLottery()
        {
            throw new NotImplementedException();
        }

        public override LotteryParticipant DeserializeParticipant(string fileName)
        {
            throw new NotImplementedException();
        }

        public override void SerializeLottery(Lottery loter, WinningTicket TicetWin)
        {
            throw new NotImplementedException();
        }

        public override void SerializeParticipant(LotteryParticipant participant)
        {
            throw new NotImplementedException();
        }
    }
}
