using System.Collections.Generic;

namespace PetVacinas.Core.Interfaces
{
    public interface IAnimalService
    {
        void CadastrarAnimal(IAnimal animal); // Acessa o Adicionar do repositório Animal
        IAnimal ObterAnimalPorId(int id); // Acessa o ObterPorId do repositório Animal
        IEnumerable<IAnimal> ObterTodosAnimais(); // Acessa o ObterTodos do repositório Animal
        void RegistrarVacinacao(int animalId, IVacinacao vacinacao); // Acessa o Adicionar do repositório Vacinacao
        IEnumerable<IVacinacao> ObterHistoricoDeVacinacoes(int animalId);
    }
}