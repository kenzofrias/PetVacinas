using System.Collections.Generic;

namespace PetVacinas.Core.Interfaces
{
    public interface IAnimalRepositorio
    {
        void Adicionar(IAnimal animal);
        IAnimal ObterPorId(int id);
        IEnumerable<IAnimal> ObterTodos();
    }
}