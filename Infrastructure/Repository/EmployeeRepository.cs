using AutoMapper;
using Domain.DTOs;
using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly CamadasContext _context;
        public EmployeeRepository(CamadasContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetEmployeeByDto(EmployeeDto dto)
        {
            return await _context.Employee.Include(x => x.Profile)
                        .FirstOrDefaultAsync(x => x.Email == dto.Email && x.Password == dto.Password);

        }

        public async Task<ActionResult<dynamic>> GetEmployee()
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                List<Employee> employee = await _context.Employee.ToListAsync();

                return employee;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o retorno dos dados." };
            }
        }

        public async Task<ActionResult<dynamic>> GetEmployee(int id)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }
                var employee = await _context.Employee.FindAsync(id);

                if (employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                return employee;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o retorno dos dados do funcionário." };
            }
        }

        public async Task<ActionResult<dynamic>> PutEmployee(int id, FuncionarioPutRequest request)
        {
            try
            {
                if (id != request.Id)
                {
                    return new { Message = "O Id do funcionário informado é diferente do Id da URL." };
                }

                Employee employee = await _context.Employee.FindAsync(id);

                employee.Salary = request.Salary;

                _context.Entry(employee).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(id))
                    {
                        return new { Message = "Não existe funcionário com o Id informado." };
                    }
                    else
                    {
                        throw;
                    }
                }

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante a atualização do funcionário." };
            }
        }

        public async Task<ActionResult<dynamic>> PostEmployee(FuncionarioRequest request)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                IMapper mapper = ConfigurePostMapper();

                Employee employee = mapper.Map<Employee>(request);

                _context.Employee.Add(employee);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de inclusão de funcionário." };
            }
        }
        public async Task<ActionResult<dynamic>> DeleteEmployee(int id)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }
                var employee = await _context.Employee.FindAsync(id);
                if (employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo a exclusão do funcionário." };
            }
        }

        public async Task<ActionResult<dynamic>> DeleteManager(int id)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }
                var employee = await _context.Employee.FindAsync(id);
                if (employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante a exclusão do funcionário." };
            }
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employee?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private static IMapper ConfigurePostMapper()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<FuncionarioRequest,
                                                                Employee>());
            var mapper = configuration.CreateMapper();
            return mapper;
        }
    }
}
