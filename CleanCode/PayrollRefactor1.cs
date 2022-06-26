using System;
namespace CleanCode
{
    public class PayrollRefactor1
    {
        public PayrollRefactor1()
        {
        }
        public Money CalculatePay(Employee employee)
        {
            return employee.CalculatePay();
        }
    }
}

