using System;
using System.IO;
using System.Linq;
using AddressProcessing.Interfaces;
using static AddressProcessing.Enumerations.Enumerations;

namespace AddressProcessing.CSV
{
    /*
        2) Refactor this class into clean, elegant, rock-solid & well performing code, without over-engineering.
           Assume this code is in production and backwards compatibility must be maintained.
    */
    public class CsvReaderWriter  :IReaderWriter
    {
        private StreamReader _readerStream;
        private StreamWriter _writerStream;
        
        public void Open(string fileName, Mode mode)
        {
            switch (mode)
            {
                case Mode.Read: _readerStream = File.OpenText(fileName); break;
                case Mode.Write:
                    FileInfo fileInfo = new FileInfo(fileName);
                    _writerStream = fileInfo.CreateText();
                    break;
                default: throw new Exception("Unknown file mode for " + fileName); 
            }

        }

        public void Write(params string[] columns)
        {
            string outPut = "";

            //for (int i = 0; i < columns.Length; i++)
            //{
            //    outPut += columns[i];
            //    if ((columns.Length - 1) != i)
            //    {
            //        outPut += "\t";
            //    }

            //}

            foreach (var col in columns)
            {
                outPut += col;
                // As in above we dont add \t for the last element of the array...
                if(Array.IndexOf(columns, col)!= Array.IndexOf(columns, columns.LastOrDefault()))
                outPut += "\t";
            }

            using (_writerStream)  //writing happens one line so closing the connection is handled by using statement
            {
                _writerStream.WriteLine(outPut);
            }
        }


        public bool Read(out string name, out string address)
        {

            name = null;
            address = null;

            char[] separator = { '\t' };

             var userInfo = _readerStream.ReadLine()?.Split(separator);

            if (userInfo?.Length > 0)
            {
                name = userInfo[(int) Columns.First];
                address = userInfo[(int) Columns.Second];
                return true;
            }

            return false;
        }
  
        public void Close()
        {
            // Closing handled by the using statement so no need for this...

            //if (_writerStream != null)
            //{
            //    _writerStream.Close();
            //}

            _readerStream?.Close();
        }
    }
}
