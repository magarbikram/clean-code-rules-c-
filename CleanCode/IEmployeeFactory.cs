namespace CleanCode
{
    public interface IEmployeeFactory
    {
        Employee MakeEmployee(EmployeeRecord employeeRecord);
    }
}