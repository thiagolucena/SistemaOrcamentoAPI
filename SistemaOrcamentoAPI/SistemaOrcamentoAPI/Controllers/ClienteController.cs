using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using ApplicationDTO.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaOrcamentoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServiceApplication _clienteServiceApplication;
        public ClienteController(IClienteServiceApplication clienteServiceApplication)
        {
            _clienteServiceApplication = clienteServiceApplication;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var retorno = await _clienteServiceApplication.List();
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar cliente.");
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id == 0)
                    return NotFound();

                var retorno = await _clienteServiceApplication.GetEntityById(id);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar cliente.");
            }
        }

        [HttpPost("GetName")]
        public async Task<IActionResult> PostName([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (clienteDTO == null)
                    return NotFound();

                var retorno = await _clienteServiceApplication.GetEntityByName(clienteDTO.Nome);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar cliente.");
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (clienteDTO == null)
                    return NotFound();

                var retorno = await _clienteServiceApplication.Add(clienteDTO);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao cadastrar cliente.");
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != clienteDTO.ClienteId)
                {
                    return BadRequest();
                }
                else
                {
                    clienteDTO.ClienteId = id;
                }


                var retorno = await _clienteServiceApplication.Update(clienteDTO);
                return Ok(retorno);
            }

            catch (Exception e)
            {
                return BadRequest("Falha ao alterar cliente.");
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id == 0)
                {
                    return BadRequest();
                }

                var retorno = await _clienteServiceApplication.GetEntityById(id);
                var objRetorno = await _clienteServiceApplication.Delete(retorno);
                return Ok(objRetorno);
            }

            catch (Exception e)
            {
                return BadRequest("Falha ao deletar cliente.");
            }

        }
    }
}
