using System.Collections.Generic;
using PetVacinas.Core.Models;

namespace PetVacinas.Core.Interfaces
{
    public interface IAnimalRepositorio
    {
        IAnimal Adicionar(IAnimal animal);
        IAnimal ObterPorId(int id);
        IEnumerable<IAnimal> ObterTodos();
    }
}