using System;
namespace CleanCode
{
    public class Payroll
    {
        public Payroll()
        {
        }

        public Money CalculatePay(Employee employee)
        {
            switch (employee.Type)
            {
                case EmployeeType.Commissioned:
                    return CalculateCommissionedPay(employee);
                case EmployeeType.Hourly:
                    return CalculateHourlyPay(employee);
                case EmployeeType.Salaried:
                    return CalculateSalariedPay(employee);
                default:
                    throw new InvalidEmployeeTypeException(employee.Type);
            }
        }

        private Money CalculateSalariedPay(Employee employee)
        {
            throw new NotImplementedException();
        }

        private Money CalculateHourlyPay(Employee employee)
        {
            throw new NotImplementedException();
        }

        private Money CalculateCommissionedPay(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}

