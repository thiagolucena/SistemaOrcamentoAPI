using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDTO.DTO
{
    public class ItemDTO
    {
        public ItemDTO()
        {
            ListItemOrcamentoDTO = new HashSet<ItemOrcamentoDTO>();
        }
        public int ItemId { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public string Descricao { get; set; }

        public ICollection<ItemOrcamentoDTO> ListItemOrcamentoDTO { get; set; }
    }
}
