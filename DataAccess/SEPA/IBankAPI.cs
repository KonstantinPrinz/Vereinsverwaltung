using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;
public interface IBankAPI
{
    public double GetBalance(string iban);

    public IEnumerable<object> GetHistory(string iban, DateTime start, DateTime end);

    public SEPAState GetSEPAState(string mandateReference);

    public void SetupSEPA(string creditorIban, SEPA sepa);

    public void CancelSEPA(string mandateReference);

    public string GetCreditorId(string iban);
}
