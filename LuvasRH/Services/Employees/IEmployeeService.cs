using LuvasRH.Models;

namespace LuvasRH.Services.Employees
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Guid id);
        object GetAll();
        Employee GetEmployee(Guid id);
        void UpsertEmployee(Employee employee);
    }
}
