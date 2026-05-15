using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVacinas.Core.Interfaces
{
    public interface IVacinaRepositorio
    {
        void Adicionar(IVacina vacina);
        IVacina ObterPorId(int id);
        IEnumerable<IVacina> ObterTodas();
    }
}