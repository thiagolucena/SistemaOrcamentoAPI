using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class ItemOrcamentoService : GenericService<ItemOrcamento>, IItemOrcamentoService
    {

        public readonly IItemOrcamentoRepository _itemOrcamentoRepository;

        public ItemOrcamentoService(IItemOrcamentoRepository itemOrcamentoRepository)
            : base(itemOrcamentoRepository)
        {
            _itemOrcamentoRepository = itemOrcamentoRepository;
        }

    }
}
