using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IServices
{
    public interface IItemService : IGenericService<Item>
    {
        Item GetEntityByName(string nome);
    }
}
