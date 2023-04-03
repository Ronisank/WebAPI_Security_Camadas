using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByDto(EmployeeDto dto);
        Task<ActionResult<dynamic>> GetEmployee();
        Task<ActionResult<dynamic>> GetEmployee(int id);
        Task<ActionResult<dynamic>> PutEmployee(int id, FuncionarioPutRequest employee);
        Task<ActionResult<dynamic>> PostEmployee(FuncionarioRequest request);
        Task<ActionResult<dynamic>> DeleteEmployee(int id);
        Task<ActionResult<dynamic>> DeleteManager(int id);

    }
}
