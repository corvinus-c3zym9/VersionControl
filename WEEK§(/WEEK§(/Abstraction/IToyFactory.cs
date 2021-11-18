using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEEK__.Abstractions;

namespace WEEK__.Abstraction
{
    public interface IToyFactory
    {
        Toy CreateNew();
    }
}
