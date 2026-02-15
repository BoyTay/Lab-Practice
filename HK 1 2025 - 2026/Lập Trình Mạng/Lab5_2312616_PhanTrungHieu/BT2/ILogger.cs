using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BT2
{
    public interface ILogger
    {
        void writeEntry(ArrayList entry);
        void writeEntry(string entry);
    }
}
