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
        WinningTicket DetermineWinner(); // определяет победителя лотереи
        void CancelLottery(); // отменяет лотерею
        bool SellAdditionalTickets(LotteryParticipant participant, int count); // продает дополнительные билеты участнику учитывает баланс и жадность
        TicetBase Buy(LotteryParticipant person); // покупает один билет для указанного участника
        void DistributeTickets(List<LotteryParticipant> participants); // распределяет билеты между участниками
    }
}
