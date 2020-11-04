using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDTO.DTO
{
    public class ItemOrcamentoDTO
    {
        public int OrcamentoId { get; set; }
        public int ItemId { get; set; }
        public ItemDTO Item { get; set; }
        public OrcamentoDTO Orcamento { get; set; }
    }
}
