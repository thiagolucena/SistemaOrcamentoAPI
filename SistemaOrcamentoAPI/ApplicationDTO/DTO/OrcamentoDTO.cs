using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDTO.DTO
{
    public class OrcamentoDTO
    {
        public OrcamentoDTO()
        {
            ListItemOrcamento = new HashSet<ItemOrcamentoDTO>();
        }

        public int OrcamentoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataOrcamento { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string UsuarioCriacao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorDesconto { get; set; }
        public bool Situacao { get; set; }

        public ICollection<ItemOrcamentoDTO> ListItemOrcamento { get; set; }
    }
}
