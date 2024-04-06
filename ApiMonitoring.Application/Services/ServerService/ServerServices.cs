using ApiMonitoring.Application.DTOs.ServerDtos;
using ApiMonitoring.Application.Exceptions;
using ApiMonitoring.Domain.Entities;
using ApiMonitoring.Persistance.AppDbContext;
using ApiMonitoring.Persistance.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMonitoring.Application.Services.ServerService
{

    public class ServerService : IServerServices
    {
        private readonly IGenericRepository<Server> _serverRepository;
        private readonly IMapper _mapper;


        public ServerService(IGenericRepository<Server> serverRepository, IMapper mapper)
        {
            _serverRepository = serverRepository;
            _mapper = mapper;
        }

        public async Task<Server> CreateAsync(ServerDto serverDto)
        {
            if (serverDto == null)
            {
                throw new ArgumentNullException(nameof(serverDto));
            }

            var server = _mapper.Map<ServerDto, Server>(serverDto);
     
            server.Id = Guid.NewGuid();

            await _serverRepository.AddAsync(server);
            await _serverRepository.SaveChangesAsync();


            return server;
        }


        public async Task DeleteAsync(Guid id)
        {
            var server = await _serverRepository.GetByIdAsync(id);
            if (server == null)
            {
                throw new ServerNotFoundException();
            }
            _serverRepository.Delete(server);
            _serverRepository.SaveChangesAsync();
        
        }

        public async Task<IEnumerable<Server>> GetAllAsync()
        {
            return  _serverRepository.GetAll();
        }

        public async Task<Server> GetByIdAsync(Guid id)
        {
            return await _serverRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Guid Id ,ServerDto serverDto)
        {
            var server = await _serverRepository.GetByIdAsync(Id);
            if (server == null)
            {
                throw new ServerNotFoundException();
            }
            _mapper.Map(serverDto, server);
            // Optionally, add validation logic here for updated server properties
             _serverRepository.Update(server);
            _serverRepository.SaveChangesAsync();
        }
    }


}
