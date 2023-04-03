using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Service
{
    public interface IAuthenticationService
    {
        Task<ActionResult<dynamic>> AuthenticateUser(EmployeeDto dto);

    }
}
