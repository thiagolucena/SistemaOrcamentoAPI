using Application;
using Domain.Models;
using Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces.IServices;
using ApplicationDTO.DTO;
using AutoMapper;
using System.Linq;

namespace Application
{
    public class ClienteServiceApplication : IClienteServiceApplication
    {
        private readonly IMapper _mapper;

        public IClienteService _clienteService;
        public ClienteServiceApplication(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Add(ClienteDTO objeto)
        {
            var map = _mapper.Map<ClienteDTO, Cliente>(objeto);
            await _clienteService.Add(map);
            var retorno = List().Result.Where(e => e.Endereco == objeto.Endereco && e.Nome == objeto.Nome).FirstOrDefault();
            return retorno;
        }

        public async Task<ClienteDTO> Delete(ClienteDTO objeto)
        {
            var map = _mapper.Map<ClienteDTO, Cliente>(objeto);
            await _clienteService.Delete(map);
            var retorno = GetEntityById(objeto.ClienteId).Result;
            return retorno;
        }

        public async Task<ClienteDTO> GetEntityById(int Id)
        {

            var retorno = await _clienteService.GetEntityById(Id);
            return _mapper.Map<Cliente, ClienteDTO>(retorno);
        }

        public async Task<ClienteDTO> GetEntityByName(string nome)
        {
            var retorno = _clienteService.GetEntityByName(nome);
            return _mapper.Map<Cliente, ClienteDTO>(retorno);
        }

        public async Task<List<ClienteDTO>> List()
        {
            var retorno = await _clienteService.List();
            return _mapper.Map<List<Cliente>, List<ClienteDTO>>(retorno);
        }

        public async Task<ClienteDTO> Update(ClienteDTO objeto)
        {
            var map = _mapper.Map<ClienteDTO, Cliente>(objeto);
            await _clienteService.Update(map);
            var retorno = GetEntityById(objeto.ClienteId).Result;
            return retorno;
        }
    }
}
