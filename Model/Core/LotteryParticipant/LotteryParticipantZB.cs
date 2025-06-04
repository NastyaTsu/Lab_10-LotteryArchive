using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public partial class LotteryParticipant : Person
    {
        public int Balance { get; private set; }
        public int Zhadnost { get; private set; }
        public void AddToBalance(int amount)
        {
            Balance += amount;
        }
        public void MinToBalance(int amount)
        {
            Balance -= amount;
        }
        public void NewBalance(int amount)
        {
            Balance = amount;
        }
        public void NewZhadnost(int amount)
        {
            Zhadnost = amount;
        }
    }
}
