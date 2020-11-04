using ApplicationDTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IItemServiceApplication
    {
        Task<ItemDTO> Add(ItemDTO objeto);
        Task<ItemDTO> Update(ItemDTO objeto);
        Task<ItemDTO> Delete(ItemDTO objeto);
        Task<ItemDTO> GetEntityById(int Id);
        Task<ItemDTO> GetEntityByName(string nome);
        Task<List<ItemDTO>> List();
    }
}
