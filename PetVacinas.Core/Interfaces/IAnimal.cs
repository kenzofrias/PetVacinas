using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVacinas.Core.Interfaces
{
    public interface IAnimal
    {
        int Id { get; }
        string Nome { get; }
        string Raca { get; }
        string Dono { get; }
        IReadOnlyCollection<Vacinacao> Vacinacoes { get; }
    }
}