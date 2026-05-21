using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;

namespace PetVacinas.Core.Models
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepositorio _animalRepositorio;
        public AnimalService()
        {
            _animalRepositorio = new AnimalRepositorio();
        }   

        public IAnimal CadastrarAnimal(IAnimal animal)
        {
            _animalRepositorio.Adicionar(animal);
            return animal;
        }

        public IAnimal ObterAnimalPorId(int id)
        {
            var animal = _animalRepositorio.ObterPorId(id);
            Console.WriteLine(animal.ToString());
            return animal;
        }

        public IEnumerable<IVacinacao> ObterHistoricoDeVacinacoes(int animalId)
        {
            var animal = _animalRepositorio.ObterPorId(animalId);
            foreach (var vacinacao in animal.Vacinacoes)
            {
                Console.WriteLine(vacinacao.ToString());
            }
            return animal.Vacinacoes;
        }

        public IEnumerable<IAnimal> ObterTodosAnimais()
        {
            var animais = _animalRepositorio.ObterTodos();
            foreach (var animal in animais)
            {
                Console.WriteLine(animal.ToString());
            }
            return animais;
        }

        public IVacinacao RegistrarVacinacao(int animalId, IVacinacao vacinacao)
        {
            var animal = _animalRepositorio.ObterPorId(animalId);
            return animal.RegistrarVacinacaoAnimal(vacinacao);
        }
    }
}