namespace CleanCode
{
    public abstract class Employee
    {
        public EmployeeType Type { get; internal set; }
        public abstract bool IsPayDay();
        public abstract Money CalculatePay();
        public abstract void DeliverPay(Money pay);
    }
}