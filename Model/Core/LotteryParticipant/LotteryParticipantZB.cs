using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public partial class LotteryParticipant : Person
    {
        public int Balance { get; set; }
        public int Zhadnost { get; set; }
    }
}
