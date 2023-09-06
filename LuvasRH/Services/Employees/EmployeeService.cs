using LuvasRH.Models;

namespace LuvasRH.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private static readonly Dictionary<Guid, Employee> _employeeMap = new Dictionary<Guid, Employee>();
        public void CreateEmployee(Employee employee)
        {
            _employeeMap.Add(employee.Id, employee);
        }

        public void DeleteEmployee(Guid id)
        {
            _employeeMap.Remove(id);
        }

        public object GetAll()
        {
            return _employeeMap.Values;
        }

        public Employee GetEmployee(Guid id)
        {
            return _employeeMap[id];
        }

        public void UpsertEmployee(Employee employee)
        {
            _employeeMap[employee.Id] = employee;

        }
    }
}
