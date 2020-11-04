using ApplicationDTO.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteServiceApplication
    {
        Task<ClienteDTO> Add(ClienteDTO objeto);
        Task<ClienteDTO> Update(ClienteDTO objeto);
        Task<ClienteDTO> Delete(ClienteDTO objeto);
        Task<ClienteDTO> GetEntityById(int Id);
        Task<ClienteDTO> GetEntityByName(string nome);
        Task<List<ClienteDTO>> List();
    }
}
