using Data.Configuration;
using Domain.Interfaces.IRepository;
using Domain.Models;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Data.Repository
{
    public class ItemOrcamentoRepository : GenericRepository<ItemOrcamento>, IItemOrcamentoRepository
    {
        public ItemOrcamentoRepository(ContextBase contextBase)
            : base(contextBase)
        {

        }
    }
}
