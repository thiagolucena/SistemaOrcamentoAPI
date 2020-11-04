using Data.Configuration;
using Domain.Interfaces.IRepository;
using Domain.Models;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Data.Repository
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ContextBase contextBase)
            : base(contextBase)
        {

        }
        public Item GetEntityByName(string nome)
        {
            return _contextBase.Item.FirstOrDefault(c => c.Descricao.Equals(nome));
        }

    }
}
