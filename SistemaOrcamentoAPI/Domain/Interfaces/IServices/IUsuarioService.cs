using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IServices
{
    public interface IUsuarioService : IGenericService<Usuario>
    {
        Usuario GetEntityByName(string nome);
        Usuario GetEntityByLogin(string login);
    }
}
