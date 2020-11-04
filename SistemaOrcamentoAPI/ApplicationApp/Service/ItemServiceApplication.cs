using Application.Interfaces;
using ApplicationDTO.DTO;
using AutoMapper;
using Domain.Interfaces.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ItemServiceApplication : IItemServiceApplication
    {
        private readonly IMapper _mapper;

        public IItemService _itemService;
        public ItemServiceApplication(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }
        public async Task<ItemDTO> Add(ItemDTO objeto)
        {
            var map = _mapper.Map<ItemDTO, Item>(objeto);
            await _itemService.Add(map);
            var retorno = List().Result.OrderByDescending(o => o.ItemId).FirstOrDefault();
            return retorno;
        }

        public async Task<ItemDTO> Delete(ItemDTO objeto)
        {
            var map = _mapper.Map<ItemDTO, Item>(objeto);
            await _itemService.Delete(map);
            var retorno = GetEntityById(objeto.ItemId).Result;
            return retorno;
        }

        public async Task<ItemDTO> GetEntityById(int Id)
        {
            var retorno = await _itemService.GetEntityById(Id);
            return _mapper.Map<Item, ItemDTO>(retorno);
        }

        public async Task<ItemDTO> GetEntityByName(string nome)
        {
            var retorno = _itemService.GetEntityByName(nome);
            return _mapper.Map<Item, ItemDTO>(retorno);
        }

        public async Task<List<ItemDTO>> List()
        {
            var retorno = await _itemService.List();
            return _mapper.Map<List<Item>, List<ItemDTO>>(retorno);
        }

        public async Task<ItemDTO> Update(ItemDTO objeto)
        {
            var map = _mapper.Map<ItemDTO, Item>(objeto);
            await _itemService.Update(map);
            var retorno = GetEntityById(objeto.ItemId).Result;
            return retorno;
        }
    }
}
