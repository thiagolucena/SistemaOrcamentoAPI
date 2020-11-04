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
    public class OrcamentoController : ControllerBase
    {
        private readonly IOrcamentoServiceApplication _orcamentoServiceApplication;

        public OrcamentoController(IOrcamentoServiceApplication orcamentoServiceApplication)
        {
            _orcamentoServiceApplication = orcamentoServiceApplication;
        }

        // GET: api/<OrcamentoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var retorno = await _orcamentoServiceApplication.List();
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar orçamento.");
            }
        }

        // GET api/<OrcamentoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id == 0)
                    return NotFound();

                var retorno = await _orcamentoServiceApplication.GetEntityById(id);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar orçamneto.");
            }
        }

        // POST api/<OrcamentoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrcamentoDTO orcamentoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (orcamentoDTO == null)
                    return NotFound();

                var retorno = await _orcamentoServiceApplication.Add(orcamentoDTO);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao cadastrar orçamento.");
            }
        }

        // PUT api/<OrcamentoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrcamentoDTO orcamentoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != orcamentoDTO.OrcamentoId)
                {
                    return BadRequest();
                }


                var retorno = await _orcamentoServiceApplication.Update(orcamentoDTO);
                return Ok(retorno);
            }

            catch (Exception e)
            {
                return BadRequest("Falha ao alterar orçamento.");
            }
        }

        // DELETE api/<OrcamentoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] OrcamentoDTO orcamentoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != orcamentoDTO.OrcamentoId)
                {
                    return BadRequest();
                }


                var retorno = await _orcamentoServiceApplication.Delete(orcamentoDTO);
                return Ok(retorno);
            }

            catch (Exception e)
            {
                return BadRequest("Falha ao deletar orçamento.");
            }

        }
    }
}
