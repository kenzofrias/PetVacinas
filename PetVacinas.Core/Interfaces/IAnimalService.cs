using System.Collections.Generic;

namespace PetVacinas.Core.Interfaces
{
    public interface IAnimalService
    {
        IAnimal CadastrarAnimal(IAnimal animal); // Acessa o Adicionar do repositório Animal
        IAnimal ObterAnimalPorId(int id); // Acessa o ObterPorId do repositório Animal
        IEnumerable<IAnimal> ObterTodosAnimais(); // Acessa o ObterTodos do repositório Animal
        IVacinacao RegistrarVacinacao(int animalId, IVacinacao vacinacao); // Acessa o Adicionar do repositório Animal e Vacinação
        IEnumerable<IVacinacao> ObterHistoricoDeVacinacoes(int animalId);
    }
}