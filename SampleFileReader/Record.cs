using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFileReader
{
    public class Record
    {
        public Record(string line)
        {
            this.Line = line;
        }

        public string Line { get; private set; }

        public DateTime Start => DateTime.Parse(Line.Split(',')[0]);

        public DateTime End => DateTime.Parse(Line.Split(',')[1]);

        public long ID => Convert.ToInt64(Line.Split(',')[2]);

        public TimeSpan Duration => End - Start;
    }
}
