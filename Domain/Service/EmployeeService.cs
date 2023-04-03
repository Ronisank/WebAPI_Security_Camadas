using Domain.DTOs;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace Domain.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ActionResult<dynamic>> GetEmployee()
        {
            return await _employeeRepository.GetEmployee();
        }

        public async Task<ActionResult<dynamic>> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        public async Task<ActionResult<dynamic>> PutEmployee(int id, FuncionarioPutRequest employee)
        {
            return await _employeeRepository.PutEmployee(id, employee);
        }


        public async Task<ActionResult<dynamic>> PostEmployee(FuncionarioRequest request)
        {
            return await _employeeRepository.PostEmployee(request);
        }

        public async Task<ActionResult<dynamic>> DeleteEmployee(int id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<ActionResult<dynamic>> DeleteManager(int id)
        {
            return await _employeeRepository.DeleteManager(id);
        }


    }
}
