using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVacinas.Core.Interfaces
{
    public interface IVacinacaoRepositorio
    {
        IVacinacao Adicionar(IVacinacao vacinacao);
        IVacinacao ObterPorId(int id);
        IEnumerable<IVacinacao> ObterTodas();
    }
}