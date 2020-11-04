using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IRepository
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario GetEntityByName(string nome);
        Usuario GetEntityByLogin(string login);
    }
}
