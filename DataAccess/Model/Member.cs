using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model;
public class Member
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName{ get; set; }
    public string IBAN { get; set; }
    public DateTime BirthDate { get; set; }
    public EmploymentType EmploymentType { get; set; }
}
