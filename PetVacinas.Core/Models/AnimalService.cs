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

        public void CadastrarAnimal(IAnimal animal)
        {
            _animalRepositorio.Adicionar(animal);
        }

        public void ObterAnimalPorId(int id)
        {
            var animal = _animalRepositorio.ObterPorId(id);
            Console.WriteLine(animal.ToString());
        }

        public void ObterHistoricoDeVacinacoes(int animalId)
        {
            var animal = _animalRepositorio.ObterPorId(animalId);
            foreach (var vacinacao in animal.Vacinacoes)
            {
                Console.WriteLine(vacinacao.ToString());
            }
        }

        public void ObterTodosAnimais()
        {
            var animais = _animalRepositorio.ObterTodos();
            foreach (var animal in animais)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        public void RegistrarVacinacao(int animalId, IVacinacao vacinacao)
        {
            var animal = _animalRepositorio.ObterPorId(animalId);
            animal.RegistrarVacinacaoAnimal(vacinacao);
        }
    }
}