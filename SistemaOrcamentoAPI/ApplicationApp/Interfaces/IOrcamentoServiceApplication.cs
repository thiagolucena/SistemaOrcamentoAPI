using ApplicationDTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrcamentoServiceApplication
    {
        Task<OrcamentoDTO> Add(OrcamentoDTO objeto);
        Task<OrcamentoDTO> Update(OrcamentoDTO objeto);
        Task<OrcamentoDTO> Delete(OrcamentoDTO objeto);
        Task<OrcamentoDTO> GetEntityById(int Id);
        Task<List<OrcamentoDTO>> List();
    }
}
