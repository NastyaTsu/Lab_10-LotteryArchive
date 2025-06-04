using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Person
{
    public interface IPerson
    {
        string Firstname { get; }
        string Lastname { get; }
        string Fullname { get; }
    }
}
