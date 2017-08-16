using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.Enumerations
{
    public static class Enumerations
    {
        // Gets 0 and 1 for flags this way which is perfectly fine for Flags attribute
        [Flags]
        public enum Mode
        {
            Read,
            Write
        };

        public enum Columns
        {
            First,
            Second
        };
    }
}
