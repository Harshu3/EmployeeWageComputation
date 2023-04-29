using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    internal class CompanyEmpWage
    {
        public string companyName;
        public int empRatePerHr, numOfWorkingDays, maxWorkingHrs,totalWage;

        public CompanyEmpWage(string companyName, int empRatePerHr, int numOfWorkingDays, int maxWorkingHrs)
        {
            this.companyName = companyName;
            this.empRatePerHr = empRatePerHr;
            this.numOfWorkingDays = numOfWorkingDays;
            this.maxWorkingHrs = maxWorkingHrs;
        }

        public void SetTotalWage(int totalWage)
        {
            this.totalWage = totalWage;
        }

        public override string ToString()
        {
            return $"Company Name:{companyName} , Emp Rate:{empRatePerHr} , Working Days:{numOfWorkingDays} , Working Hrs:{maxWorkingHrs} , Total Wage:{totalWage}";
        }
    }
}
