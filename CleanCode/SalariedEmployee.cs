namespace CleanCode
{
    internal class SalariedEmployee : Employee
    {
        public override Money CalculatePay()
        {
            throw new NotImplementedException();
        }

        public override void DeliverPay(Money pay)
        {
            throw new NotImplementedException();
        }

        public override bool IsPayDay()
        {
            throw new NotImplementedException();
        }
    }
}