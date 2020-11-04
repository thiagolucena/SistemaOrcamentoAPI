using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class ClienteService : GenericService<Cliente>, IClienteService
    {

        public readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente GetEntityByName(string nome)
        {
            return _clienteRepository.GetEntityByName(nome);
        }

    }
}
