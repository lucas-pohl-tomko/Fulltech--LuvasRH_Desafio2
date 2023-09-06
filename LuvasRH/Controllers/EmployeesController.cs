using LuvasRH.Lib.Employee;
using LuvasRH.Models;
using LuvasRH.Services.Employees;
using Microsoft.AspNetCore.Mvc;

namespace LuvasRH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult GetResponse()
        {
            return Ok("lets get it");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult CreateEmployee(CreateEmployeeRequest request)
        {
            if(request.Age < 18)
            {
                return BadRequest("You're too young to work here pall");
            }

            var employee = new Employee(
                Guid.NewGuid(),
                request.Name,
                request.FederalDocument,
                request.Age,
                request.Role,
                request.Department,
                request.Supervisor,
                request.Salary,
                request.Admission,
                null,
                DateTime.UtcNow
                );

            _employeeService.CreateEmployee( employee );

            var response = new EmployeeResponse(employee.Id, employee.Name, 
                employee.FederalDocument, 
                employee.Age, employee.Role, 
                employee.Department, employee.Supervisor, 
                employee.Salary, employee.Admission, 
                employee.Dismissal, employee.LastModified);

            return CreatedAtAction(
                actionName: nameof(GetEmployee),
                routeValues: new { id = employee.Id },
                value: response
                );
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployee(Guid id)
        {
            Employee employee = _employeeService.GetEmployee(id);
            var response = new EmployeeResponse(
                employee.Id,
                employee.Name,
                employee.FederalDocument,
                employee.Age,
                employee.Role,
                employee.Department,
                employee.Supervisor,
                employee.Salary,
                employee.Admission,
                employee.Dismissal,
                employee.LastModified
                );
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertEmployee(Guid id, UpsertEmployeeRequest request)
        {
            var employee = new Employee(
                id,
                request.Name,
                request.FederalDocument,
                request.Age,
                request.Role,
                request.Department,
                request.Supervisor,
                request.Salary,
                request.Admission,
                request.Dismissal,
                DateTime.UtcNow
                );
            _employeeService.UpsertEmployee(employee);

            // TODO: return 201 if a new employee was created
            return Ok(employee);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok(id);
        }
    }
}
