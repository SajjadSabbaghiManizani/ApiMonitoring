using ApiMonitoring.Application.DTOs.ServerDtos;
using ApiMonitoring.Domain.Entities;
using ApiMonitoring.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMonitoring.Application.Services.ServerService
{
    public interface IServerServices 
    {
        Task<Server> GetByIdAsync(Guid id);
        Task<IEnumerable<Server>> GetAllAsync();
        Task<Server> CreateAsync(ServerDto server);
        Task UpdateAsync(Guid id , ServerDto server);
        Task DeleteAsync(Guid id);
    }
}
