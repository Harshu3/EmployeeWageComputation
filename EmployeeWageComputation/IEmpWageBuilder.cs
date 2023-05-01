using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    internal interface IEmpWageBuilder
    {
        void AddCompanies(string companyName, int empRatePerHr, int numOfWorkingDays, int maxWorkingHrs);
        int CalculateEmpWage(CompanyEmpWage companyEmpWage);
    }
}
