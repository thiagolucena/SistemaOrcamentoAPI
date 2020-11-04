using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ItemOrcamento
    {
        public int OrcamentoId { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public Orcamento Orcamento { get; set; }
    }
}
