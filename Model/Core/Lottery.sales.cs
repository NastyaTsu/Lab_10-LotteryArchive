using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public partial class Lottery
    {
        public bool SellAdditionalTickets(LotteryParticipant participant, int count)
        {
            if (participant == null || count <= 0)
                return false;

            // Проверяем, сколько билетов может купить участник исходя из его жадности и баланса
            int maxCanBuy = (int)(participant.Balance / (10 * (1 + participant.Zhadnost / 10.0)));
            count = Math.Min(count, maxCanBuy);

            if (count == 0)
                return false;

            for (int i = 0; i < count; i++)
            {
                var ticket = participant.Buy(this);
                if (ticket == null) break;
                _ticket.Add(ticket);
            }

            return true;
        }
    }
}
