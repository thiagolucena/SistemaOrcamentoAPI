using ApplicationDTO.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IServices
{
    public interface IClienteService : IGenericService<Cliente>
    {
        Cliente GetEntityByName(string nome);

    }
}
