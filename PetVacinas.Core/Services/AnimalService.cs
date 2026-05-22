using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;
using PetVacinas.Core.Models;

namespace PetVacinas.Core.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepositorio _animalRepositorio;
        private readonly IVacinacaoRepositorio _vacinacaoRepositorio;
        public AnimalService()
        {
            _animalRepositorio = new AnimalRepositorio();
            _vacinacaoRepositorio = new VacinacaoRepositorio();
        }   

        public IAnimal CadastrarAnimal(IAnimal animal)
        {
            return _animalRepositorio.Adicionar(animal);
        } // Mostrar mensagem de sucesso ao cadastrar o animal

        public IAnimal ObterAnimalPorId(int id)
        {
            var animal = _animalRepositorio.ObterPorId(id);
            return animal;
        } // Mostrar detalhes do animal encontrado

        public IEnumerable<IVacinacao> ObterHistoricoDeVacinacoes(int animalId)
        {
            var animal = _animalRepositorio.ObterPorId(animalId);
            return animal.Vacinacoes;
        } // Percorrer e mostrar as vacinações do animal

        public IEnumerable<IAnimal> ObterTodosAnimais()
        {
            var animais = _animalRepositorio.ObterTodos();
            return animais;
        } // Percorrer e mostrar os detalhes de cada animal cadastrado

        public IVacinacao RegistrarVacinacao(int animalId, IVacinacao vacinacao)
        {
            var animal = _animalRepositorio.ObterPorId(animalId);
            _vacinacaoRepositorio.Adicionar(vacinacao);
            return animal.RegistrarVacinacaoAnimal(vacinacao);
        } // Mostrar mensagem de sucesso 
    }
}