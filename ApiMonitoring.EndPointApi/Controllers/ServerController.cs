using ApiMonitoring.Application.DTOs.ServerDtos;
using ApiMonitoring.Application.Exceptions;
using ApiMonitoring.Application.Services.ServerService;
using ApiMonitoring.Domain.Entities;
using ApiMonitoring.Persistance.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMonitoring.EndPointApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServerController : ControllerBase
    {
        private readonly IServerServices _serverRepository;
        private readonly IMapper _mapper;

        public ServerController(IServerServices serverRepository, IMapper mapper)
        {
            _serverRepository = serverRepository;
            _mapper = mapper;
        }

        // GET: api/Server
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var servers = await _serverRepository.GetAllAsync();
            return Ok(servers);
        }

        // GET: api/Server/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var server = await _serverRepository.GetByIdAsync(id);
            if (server == null)
            {
                return NotFound();
            }

            return Ok(server);
        }

        // POST: api/Server
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServerDto serverDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var server = await _serverRepository.CreateAsync(serverDto);
            return CreatedAtRoute(nameof(GetById), new { id = server.Id }, server);
        }

        // PUT: api/Server/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ServerDto serverDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _serverRepository.UpdateAsync(id, serverDto);
                return NoContent();
            }
            catch (ServerNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/Server/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _serverRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (ServerNotFoundException)
            {
                return NotFound();
            }
        }

    }

}
