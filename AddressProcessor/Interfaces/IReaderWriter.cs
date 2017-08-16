using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.Interfaces
{
    // in case we need in the future other readers,writers it would be good to have an Interface
    public interface IReaderWriter
    {
        void Open(string fileName, Enumerations.Enumerations.Mode mode);
        void Write(params string[] columns);
        bool Read(out string name, out string address);
        void Close();

    }
}
