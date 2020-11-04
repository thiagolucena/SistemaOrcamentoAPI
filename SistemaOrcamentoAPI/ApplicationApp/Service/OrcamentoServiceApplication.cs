using Application.Interfaces;
using ApplicationDTO.DTO;
using AutoMapper;
using Domain.Interfaces.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class OrcamentoServiceApplication : IOrcamentoServiceApplication
    {
        private readonly IMapper _mapper;

        public IOrcamentoService _orcamentoService;
        public OrcamentoServiceApplication(IOrcamentoService orcamentoService, IMapper mapper)
        {
            _orcamentoService = orcamentoService;
            _mapper = mapper;
        }

        public async Task<OrcamentoDTO> Add(OrcamentoDTO objeto)
        {
            var map = _mapper.Map<OrcamentoDTO, Orcamento>(objeto);
            await _orcamentoService.Add(map);
            var retorno = List().Result.OrderByDescending(o => o.OrcamentoId).FirstOrDefault();
            return retorno;
        }

        public async Task<OrcamentoDTO> Delete(OrcamentoDTO objeto)
        {
            var map = _mapper.Map<OrcamentoDTO, Orcamento>(objeto);
            await _orcamentoService.Delete(map);
            var retorno = GetEntityById(objeto.OrcamentoId).Result;
            return retorno;
        }

        public async Task<OrcamentoDTO> GetEntityById(int Id)
        {
            var retorno = await _orcamentoService.GetEntityById(Id);
            return _mapper.Map<Orcamento, OrcamentoDTO>(retorno);
        }

        public async Task<List<OrcamentoDTO>> List()
        {
            var retorno = await _orcamentoService.List();
            return _mapper.Map<List<Orcamento>, List<OrcamentoDTO>>(retorno);
        }

        public async Task<OrcamentoDTO> Update(OrcamentoDTO objeto)
        {
            var map = _mapper.Map<OrcamentoDTO, Orcamento>(objeto);
            await _orcamentoService.Update(map);
            var retorno = GetEntityById(objeto.OrcamentoId).Result;
            return retorno;
        }
    }
}
