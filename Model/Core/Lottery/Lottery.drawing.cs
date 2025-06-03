using Model.Core.Lottery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public partial class Lottery : ILotteryService
    {
        public event Action<WinningTicket> OnLotteryCompleted; // Делегат
        public WinningTicket DetermineWinner()
        {
            // Проверяем, продано ли более 25% билетов
            if (_ticket.Count(t => t.Owner != null) < Totaltickets * 0.25)
            {
                CancelLottery();
                return null;
            }

            // Получаем только проданные билеты
            var soldTickets = _ticket.Where(t => t.Owner != null).ToList();
            if (soldTickets.Count == 0)
                return null;

            // Выбираем случайный билет из проданных
            var random = new Random();
            var winningTicket = soldTickets[random.Next(soldTickets.Count)];

            // Создаем выигрышный билет
            var winner = new WinningTicket(this, winningTicket.Owner)
            {
                Prize = (int)(Prizefond * (0.5 + random.NextDouble() * 0.5)) // Приз 50-100% от фонда
            };

            winningTicket.Owner.AddWinning(winner.Prize);
            OnLotteryCompleted?.Invoke(winner); // Вызов события

            return winner;
        }

        public void CancelLottery()
        {
            // Возвращаем 90% стоимости билетов
            foreach (var ticket in _ticket.Where(t => t.Owner != null))
            {
                ticket.Owner.Balance += (int)(ticket.Cost * 0.9);
            }
        }
    }
}
