using ApiMonitoring.Application.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMonitoring.Application.Services.UserServices
{
    public interface IUserServices
    {
        Task<RegisterResult> RegisterUserAsync(RegisterUserDTO userDTO);

    }
}
