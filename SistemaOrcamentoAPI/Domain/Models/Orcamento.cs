using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Orcamento
    {
        public Orcamento()
        {
            ListItemOrcamento = new HashSet<ItemOrcamento>();
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

        public ICollection<ItemOrcamento> ListItemOrcamento { get; set; }

    }

}
