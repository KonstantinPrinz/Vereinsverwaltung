using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model;
public class Account
{
    public string IBAN { get; set; }
    
    public string CreditorId { get; set; }

    [JsonIgnore]
    public IEnumerable<Entry> Entries { get; set;} = new List<Entry>();

    public IEnumerable<Entry> GetEntriesInDateRange(DateTime begin, DateTime end)
    {
        return Entries.Where(e => e.TimeStamp.Ticks <= end.Date.Ticks && e.TimeStamp.Date.Ticks >= begin.Ticks);
    }

    public double GetBalance()
    {
        // Fetches the balance from the account via the api.
        throw new NotImplementedException();
    }
}
