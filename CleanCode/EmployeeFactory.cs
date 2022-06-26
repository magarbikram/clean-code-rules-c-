using System;
namespace CleanCode
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public EmployeeFactory()
        {
        }

        public Employee MakeEmployee(EmployeeRecord employeeRecord)
        {
            switch (employeeRecord.Type)
            {
                case EmployeeType.Commissioned:
                    return new CommissionedEmployee();
                case EmployeeType.Hourly:
                    return new HourlyEmployee();
                case EmployeeType.Salaried:
                    return new SalariedEmployee();
                default:
                    throw new InvalidEmployeeTypeException(employeeRecord.Type);
            }
        }
    }
}

