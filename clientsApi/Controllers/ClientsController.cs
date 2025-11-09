using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientsApi.Data;
using clientsApi.Dto;
using clientsApi.Helpers;
using clientsApi.Interfaces;
using clientsApi.Mapper;
using clientsApi.Models;
using clientsApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clientsApi.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public readonly ApplicationDBContext _context;
        private readonly IClientRepository _clientRepo;
        public ClientsController(ApplicationDBContext context, IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients([FromQuery] QueryObject Q)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clients = await _clientRepo.GetAllAsync(Q);
            var clientDto = clients.Select(c => c.ToClientDto());

            return Ok(clientDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = await _clientRepo.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client.ToClientDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientDto createdClients)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = createdClients.ToClient();

            await _clientRepo.CreateAsync(client);

            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client.ToClientDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClientDto updateClientDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = await _clientRepo.UpdateAsync(id, updateClientDto);

            if (client == null)
            {
                return NotFound();
            }


            return Ok(client.ToClientDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = await _clientRepo.DeleteAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
