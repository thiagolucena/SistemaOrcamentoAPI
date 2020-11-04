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
    public class ItemController : ControllerBase
    {

        private readonly IItemServiceApplication _itemServiceApplication;

        public ItemController(IItemServiceApplication itemServiceApplication) 
        {
            _itemServiceApplication = itemServiceApplication;
        }

        // GET: api/<ItemController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var retorno = await _itemServiceApplication.List();
                return Ok(retorno);
            }
            catch(Exception e)
            {
                return BadRequest("Falha ao consultar item.");
            }
            
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id == 0)
                    return NotFound();

                var retorno = await _itemServiceApplication.GetEntityById(id);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar item.");
            }
        }

        [HttpPost("GetName")]
        public async Task<IActionResult> PostName([FromBody] ItemDTO itemDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (itemDTO == null)
                    return NotFound();

                var retorno = await _itemServiceApplication.GetEntityByName(itemDTO.Descricao);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao consultar item.");
            }
        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemDTO itemDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (itemDTO == null)
                    return NotFound();

                var retorno = await _itemServiceApplication.Add(itemDTO);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                return BadRequest("Falha ao cadastrar item.");
            }
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ItemDTO itemDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != itemDTO.ItemId)
                {
                    return BadRequest();
                }


                var retorno = await _itemServiceApplication.Update(itemDTO);
                return Ok(retorno);
            }

            catch (Exception e)
            {
                return BadRequest("Falha ao alterar item.");
            }
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] ItemDTO itemDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != itemDTO.ItemId)
                {
                    return BadRequest();
                }


                var retorno = await _itemServiceApplication.Delete(itemDTO);
                return Ok(retorno);
            }

            catch (Exception e)
            {
                return BadRequest("Falha ao deletar item.");
            }

        }
    }
}
