using LotteryArchive.Model.Core;
using Model.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Lottery
{
    internal interface ILotteryService
    {
        WinningTicket DetermineWinner();

        void CancelLottery();
        bool SellAdditionalTickets(LotteryParticipant participant, int count);
        TicetBase Buy(LotteryParticipant person);
        void DistributeTickets(List<LotteryParticipant> participants);
    }
}
