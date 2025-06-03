using Model.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public partial class Ticket : TicetBase
    {
        private int _cost;
        public override int Cost => Math.Abs(_cost); // Гарантируем положительное значение

        public void SetCost(Lottery lottery)
        {
            if (lottery == null) throw new ArgumentNullException("Лотерея не может быть null");
            _cost = Math.Abs(lottery.Price); // Убедимся, что цена положительная
        }
    }
}
