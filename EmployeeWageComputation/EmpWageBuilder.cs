using System;

namespace EmployeeWageComputation
{
    class EmpWageBuilder
    {
        public string companyName;
        public int empRatePerHr, numOfWorkingDays, maxWorkingHrs;

        public EmpWageBuilder(string companyName, int empRatePerHr, int numOfWorkingDays, int maxWorkingHrs)
        {
            this.companyName = companyName;
            this.empRatePerHr = empRatePerHr;
            this.numOfWorkingDays = numOfWorkingDays;
            this.maxWorkingHrs = maxWorkingHrs;
        }
        public int CalculateEmpWage()
        {
            int empHrs = 0;
            int empWage = 0;
            int totalWage = 0;
            int day = 1;
            int totalHrs = 0;
            const int IS_FULL_TIME = 1;
            const int IS_PART_TIME = 2;

            Random random = new Random();
            while (day <= numOfWorkingDays && totalHrs <= maxWorkingHrs)
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
                empWage = empRatePerHr * empHrs;
                day++;
                totalHrs += empHrs;
                totalWage += empWage;
            }
            Console.WriteLine("Total Wage for {0} {1} days and {2} hrs is:{3} ", companyName, (day - 1), totalHrs, totalWage);
            return totalWage;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Wage Computation Problem");
            EmpWageBuilder deloitte = new EmpWageBuilder("Deloitte", 40, 23, 60);
            EmpWageBuilder microsoft = new EmpWageBuilder("Microsoft", 50, 26, 70);
            EmpWageBuilder infosys = new EmpWageBuilder("Infosys", 70, 33, 65);
            EmpWageBuilder accenture = new EmpWageBuilder("Accenture", 60, 36, 55);
            EmpWageBuilder capgemini = new EmpWageBuilder("Capgemini", 50, 30, 68);
            Console.WriteLine("Total Wage is: " + deloitte.CalculateEmpWage() + "\n");
            Console.WriteLine("Total Wage is: " + microsoft.CalculateEmpWage() + "\n");
            Console.WriteLine("Total Wage is: " + infosys.CalculateEmpWage() + "\n");
            Console.WriteLine("Total Wage is: " + accenture.CalculateEmpWage() + "\n");
            Console.WriteLine("Total Wage is: " + capgemini.CalculateEmpWage() + "\n");
        }
    }
}

