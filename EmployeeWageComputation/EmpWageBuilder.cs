using System;

namespace EmployeeWageComputation
{
    class EmpWageBuilder
    {
        public List<CompanyEmpWage> list;

        public EmpWageBuilder()
        {
            list = new List<CompanyEmpWage>();
        }

        public void AddCompanies(string companyName, int empRatePerHr, int numOfWorkingDays, int maxWorkingHrs)
        {
            CompanyEmpWage company = new CompanyEmpWage(companyName, empRatePerHr, numOfWorkingDays, maxWorkingHrs);
            list.Add(company);
        }

        public void FetchCompanyEmpWageFromArray()
        {
            for (int i = 0; i < list.Count; i++)
            {
                int totalWage = CalculateEmpWage(list[i]);
                list[i].SetTotalWage(totalWage);
                Console.WriteLine(list[i]);
            }
        }
        public int CalculateEmpWage(CompanyEmpWage companyEmpWage)
        {
            int empHrs = 0, empWage = 0, totalWage = 0, day = 1, totalHrs = 0;
            const int IS_FULL_TIME = 1;
            const int IS_PART_TIME = 2;

            Random random = new Random();
            while (day <= companyEmpWage.numOfWorkingDays && totalHrs <= companyEmpWage.maxWorkingHrs)
            {
                int employeeAttendance = random.Next(0, 3); //0 to 2
                switch (employeeAttendance)
                {
                    case IS_FULL_TIME:
                        //code block
                        empHrs = 8;
                        break;
                    case IS_PART_TIME:
                        //code block
                        empHrs = 4;
                        break;
                    default:
                        //code block
                        empHrs = 0;
                        break;
                }
                empWage = companyEmpWage.empRatePerHr * empHrs;
                day++;
                totalHrs += empHrs;
                totalWage += empWage;
            }
            //Console.WriteLine("Total Wage for {0} {1} days and {2} hrs is:{3} ", companyEmpWage.companyName, (day - 1), totalHrs, totalWage);
            return totalWage;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Wage Computation Problem");
            EmpWageBuilder empWageBuilder = new EmpWageBuilder();
            empWageBuilder.AddCompanies("Deloitte", 40, 23, 60);
            empWageBuilder.AddCompanies("Microsoft", 50, 26, 70);
            empWageBuilder.AddCompanies("Infosys", 70, 33, 65);
            empWageBuilder.AddCompanies("Accenture", 60, 36, 55);
            empWageBuilder.AddCompanies("Capgemini", 50, 30, 68);
            empWageBuilder.FetchCompanyEmpWageFromArray();
        }
    }
}

