using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuvasRH.Lib.Employee
{
    public record EmployeeResponse(
        Guid Id,
        string Name,
        string FederalDocument,
        int Age,
        string Role,
        string Department,
        string Supervisor,
        double Salary,
        DateTime Admission,
        DateTime? Dismissal,
        DateTime LastModified);
}
