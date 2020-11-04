using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IRepository
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Cliente GetEntityByName(string nome);
    }
}
