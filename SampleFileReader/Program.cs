using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = File.ReadAllLines(@"C:\Users\Vinod - PC\Documents\ParkLoadData.csv")
                           .Select(a => new Record(a.ToString()))
                           .GroupBy(a => a.ID)
                           .Select(a => new {
                               id =a.Key,
                               Duration = TimeSpan.FromTicks(a.Sum(r=>r.Duration.Ticks))
                           });


            using (var output = File.CreateText(@"C:\Users\Vinod - PC\Documents\summary.txt"))
            {
                foreach (var entry in summary)
                {
                    output.WriteLine($"{entry.id:D10} { entry.Duration:c}");
                }
            }
                         
                          
                 
        }
    }
}
