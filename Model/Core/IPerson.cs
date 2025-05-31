using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryArchive.Model.Core
{
    public interface IPerson
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Fullname { get; }
        static int Id { get; set; }
    }
}
