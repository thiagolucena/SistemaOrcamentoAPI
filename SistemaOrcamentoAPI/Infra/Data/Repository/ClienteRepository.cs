using Data.Configuration;
using Domain.Interfaces.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ContextBase contextBase)
            : base(contextBase)
        {

        }

        public Cliente GetEntityByName(string nome)
        {
            return _contextBase.Cliente.FirstOrDefault(c => c.Nome.Equals(nome));
        }

    }
}
