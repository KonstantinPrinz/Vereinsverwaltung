using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model;
public class Account
{
    public double Balance { get; set; }

    public IEnumerable<Entry> Entries { get; set;} = new List<Entry>();

    public IEnumerable<Entry> GetEntriesInDateRange(DateTime begin, DateTime end)
    {
        return Entries.Where(e => e.TimeStamp.Ticks <= end.Ticks && e.TimeStamp.Ticks >= begin.Ticks);
    }
}
