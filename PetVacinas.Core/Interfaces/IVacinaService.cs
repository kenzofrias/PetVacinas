using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVacinas.Core.Interfaces
{
    public interface IVacinaService
    {
        void CadastrarVacina(IVacina vacina); // Acessa o método Adicionar do repositório Vacina
        IVacina ObterVacinaPorId(int id); // Acessa o método ObterPorId do repositório Vacina
        IEnumerable<IVacina> ObterTodasVacinas(); // Acessa o método ObterTodas do repositório Vacina
    }
}