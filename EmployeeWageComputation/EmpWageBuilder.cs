using System;

namespace EmployeeWageComputation
{
    class EmpWageBuilder: IEmpWageBuilder
    {
        public List<CompanyEmpWage> list;
        public List<Dictionary<int, int>> DailyWage;
        public Dictionary<string, int> TotalWage;

        public EmpWageBuilder()
        {
            list = new List<CompanyEmpWage>();
            DailyWage = new List<Dictionary<int, int>>();
            TotalWage = new Dictionary<string, int>();
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
                TotalWage.Add(list[i].companyName, totalWage);
            }
        }

        public void DisplayTotalWage(string companyName)
        {
            if (TotalWage.ContainsKey(companyName))
            {
                Console.WriteLine("Total Wage is:" + TotalWage[companyName]);
            }
            else
            {
                Console.WriteLine("This company not exist");
            }
        }

        public void DisplayDailyWage()
        {
            for (int i = 0; i < DailyWage.Count; i++)
            {
                Console.WriteLine("\nDaily Wage of " + list[i].companyName + ":");
                foreach (KeyValuePair<int, int> vp in DailyWage[i])
                {
                    Console.Write("Day:" + vp.Key + " " + "Wage:" + vp.Value + ", ");
                }
                Console.WriteLine("\n");
            }
        }
        public int CalculateEmpWage(CompanyEmpWage companyEmpWage)
        {
            int empHrs = 0, empWage = 0, totalWage = 0, day = 1, totalHrs = 0;
            const int IS_FULL_TIME = 1;
            const int IS_PART_TIME = 2;
            Dictionary<int, int> dic = new Dictionary<int, int>();

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
                dic.Add(day, empWage);
                day++;
                totalHrs += empHrs;
                totalWage += empWage;
            }
            DailyWage.Add(dic);
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
            //empWageBuilder.DisplayDailyWage();
            Console.WriteLine("\nPlease enter company name to check total wage");
            string name = Console.ReadLine();
            empWageBuilder.DisplayTotalWage(name);
        }
    }
}

