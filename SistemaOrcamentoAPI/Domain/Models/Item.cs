using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{    public class Item
    {
        public Item()
        {
            ListItemOrcamento = new HashSet<ItemOrcamento>();
        }
        public int ItemId { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public string Descricao { get; set; }

        public ICollection<ItemOrcamento> ListItemOrcamento { get; set; }
    }

}
