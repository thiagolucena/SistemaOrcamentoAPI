using Data.Configuration;
using Domain.Interfaces.IRepository;
using Domain.Models;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ContextBase contextBase)
           : base(contextBase)
        {

        }

        public Usuario GetEntityByName(string nome)
        {
            return _contextBase.Usuario.FirstOrDefault(c => c.Nome.Equals(nome));
        }

        public Usuario GetEntityByLogin(string login)
        {
            return _contextBase.Usuario.FirstOrDefault(c => c.Login.Equals(login));
        }

    }
}
