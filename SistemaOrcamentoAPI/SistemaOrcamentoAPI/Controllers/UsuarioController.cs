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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServiceApplication _usuarioServiceApplication;
        public UsuarioController(IUsuarioServiceApplication usuarioServiceApplication)
        {
            _usuarioServiceApplication = usuarioServiceApplication;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var retorno = await _usuarioServiceApplication.List();
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar usuários.");
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id == 0)
                    return NotFound();

                var retorno = await _usuarioServiceApplication.GetEntityById(id);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar usuário.");
            }
        }

        [HttpPost("GetName")]
        public async Task<IActionResult> PostName([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (usuarioDTO == null)
                    return NotFound();

                var retorno = await _usuarioServiceApplication.GetEntityByName(usuarioDTO.Nome);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar usuário.");
            }
        }

        [HttpPost("GetLogin")]
        public async Task<IActionResult> PostLogin([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (usuarioDTO == null)
                    return NotFound();

                var retorno = await _usuarioServiceApplication.GetEntityByLogin(usuarioDTO.Login);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar usuário.");
            }
        }

        [HttpPost("RealizarLogin")]
        public async Task<IActionResult> PostRealizarLogin([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (usuarioDTO == null || string.IsNullOrEmpty(usuarioDTO.Nome) || string.IsNullOrEmpty(usuarioDTO.Senha))
                    return BadRequest("Favor informar os dados.");

                var retorno = await _usuarioServiceApplication.RealizarLogin(usuarioDTO);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar usuário.");
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (usuarioDTO == null)
                    return NotFound();

                var retorno = await _usuarioServiceApplication.Add(usuarioDTO);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao cadastrar usuário.");
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != usuarioDTO.UsuarioId)
                {
                    return BadRequest();
                }


                var retorno = await _usuarioServiceApplication.Update(usuarioDTO);
                return Ok(retorno);
            }

            catch (Exception e)
            {
                return BadRequest("Falha ao alterar usuário.");
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != usuarioDTO.UsuarioId)
                {
                    return BadRequest();
                }

                var retorno = await _usuarioServiceApplication.Delete(usuarioDTO);
                return Ok(retorno);
            }

            catch (Exception e)
            {
                return BadRequest("Falha ao deletar usuário.");
            }

        }
    }
}
