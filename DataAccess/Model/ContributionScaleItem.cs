using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model;
public class ContributionScaleItem
{
    public Guid Id { get; set; }
    public EmploymentType Employment { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public double Contribution { get; set; }
}
