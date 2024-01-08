using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Pdf;

namespace DataAccess;
public class SEPA
{
    public string MandateReference { get; set; }
    public string CreditorId { get; set; }
    public string CreditorAddress { get; set; }
    public string DebtorId { get; set; }
    public string DebtorName { get; set; }
    public string DebtorIban { get; set; }
    public SEPAPaymentType PaymentType { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }

    public PdfDocument GeneratePDF()
    {
        throw new NotImplementedException();
    }
}
