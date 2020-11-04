using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class ItemService : GenericService<Item>, IItemService
    {

        public readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
            : base(itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Item GetEntityByName(string nome)
        {
            return _itemRepository.GetEntityByName(nome);
        }
    }
}
