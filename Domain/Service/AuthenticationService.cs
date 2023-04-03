using Domain.DTOs;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITokenService _tokenService;
        public AuthenticationService(IEmployeeRepository employeeRepository, ITokenService tokenService)
        {
            _employeeRepository = employeeRepository;
            _tokenService = tokenService;
        }

        public async Task<ActionResult<dynamic>> AuthenticateUser(EmployeeDto dto)
        {
            try
            {
                var user = await _employeeRepository.GetEmployeeByDto(dto);

                if (user == null)
                {
                    return new { Message = "Funcionário e/ou senha inválidos." };
                }

                var token = _tokenService.GenerateToken(user);
                var result = new
                {
                    token,
                    User = new
                    {
                        user.Id,
                        user.Name,
                        user.Email,
                        user.ProfileId
                    }
                };
                user.Password = "";
                return new { result };
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }
    }
}
