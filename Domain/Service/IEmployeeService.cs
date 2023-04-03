using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public interface IEmployeeService
    {
        Task<ActionResult<dynamic>> GetEmployee();
        Task<ActionResult<dynamic>> GetEmployee(int id);
        Task<ActionResult<dynamic>> PutEmployee(int id, FuncionarioPutRequest employee);
        Task<ActionResult<dynamic>> PostEmployee(FuncionarioRequest request);
        Task<ActionResult<dynamic>> DeleteEmployee(int id);
        Task<ActionResult<dynamic>> DeleteManager(int id);

    }
}
