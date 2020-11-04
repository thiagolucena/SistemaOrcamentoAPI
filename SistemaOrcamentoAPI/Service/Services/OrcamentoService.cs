using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class OrcamentoService : GenericService<Orcamento>, IOrcamentoService
    {

        public readonly IOrcamentoRepository _orcamentoRepository;

        public OrcamentoService(IOrcamentoRepository orcamentoRepository)
            : base(orcamentoRepository)
        {
            _orcamentoRepository = orcamentoRepository;
        }
    }
}
