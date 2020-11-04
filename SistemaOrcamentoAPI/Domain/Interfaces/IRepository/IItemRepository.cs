using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IRepository
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Item GetEntityByName(string nome);
    }
}
