using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Models;
using Xunit;

namespace PetVacinas.Tests
{
    public class AnimalTests
    {
        private readonly AnimalService _animalService;
        public AnimalTests()
        {
            _animalService = new AnimalService();
        }

        // Sucessos
        [Fact]
        public void DeveCadastrarAnimalComSucessoNoRepositorio()
        {
            //Arrage
            var animal = new Animal("Rex", "Labrador", "João");
            //Act
            var result = _animalService.CadastrarAnimal(animal);
            //Assert
            Assert.Equal(animal, result);
        }

        [Fact]
        public void DeveObterAnimalPeloSeuId()
        {
            //Arrage
            var animal = new Animal("Biscoito", "Caramelo", "Sabrina");
            var animalCadastrado = _animalService.CadastrarAnimal(animal);
            //Act
            var result = _animalService.ObterAnimalPorId(animalCadastrado.Id);
            //Assert
            Assert.Equal(animal, result);
        }

        [Fact] // Teste deve retornar vazio pois o animal não tem vacinações registradas
        public void DeveMostrarHistoricoDeVacinacoesDoAnimalVazio()
        {
            //Arrage
            var animal = new Animal("Dolly", "Vira-lata", "André");
            var animalCadastrado = _animalService.CadastrarAnimal(animal);
            //Act
            _animalService.ObterHistoricoDeVacinacoes(animalCadastrado.Id);
            //Assert
            Assert.Empty(animalCadastrado.Vacinacoes);
        }

        [Fact]
        public void DeveObterTodosOsAnimaisCadastradosEPresentesNoRepositorio()
        {
            //Arrage
            var animal1 = new Animal("Luna", "Poodle", "Maria");
            var animal2 = new Animal("Max", "Bulldog", "Carlos");
            var animal3 = new Animal("Bella", "Golden Retriever", "Ana");
            //Act
            _animalService.CadastrarAnimal(animal1);
            _animalService.CadastrarAnimal(animal2);
            _animalService.CadastrarAnimal(animal3);
            var result = _animalService.ObterTodosAnimais();
            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count());
            Assert.Contains(result, a => a.Nome == "Luna");
            Assert.Contains(result, a => a.Nome == "Max");
            Assert.Contains(result, a => a.Nome == "Bella");
        }

        // [Fact] DeveMostrarHistoricoDeVacinacoesDoAnimalComVacinacoesRegistradas
        // NoEmpty, Equal e Contains para comparações

        // [Fact] DeveRegistrarVacinacaoComSucessoNoAnimal
        // Equal para comparar a vacinação registrada com a vacinação retornada no histórico do animal

        // Falhas
        [Fact]
        public void DeveRetornarExceçãoAoTentarCadastrarAnimalNulo()
        {
            //Arrage
            Animal animal = null;
            //Act + Assert
            Assert.Throws<ArgumentNullException>(() => _animalService.CadastrarAnimal(animal));
        }

        [Fact]
        public void DeveRetornarExceçãoAoTentarCadastrarAnimalComIdJaExistente()
        {
            //Arrange
            var animal = new Animal("Rex", "Labrador", "João");
            //Act
            _animalService.CadastrarAnimal(animal);
            //Assert
            Assert.Throws<InvalidOperationException>(() => _animalService.CadastrarAnimal(animal));
        }

        [Fact]
        public void DeveRetornarExceçãoAoTentarEncontrarAnimalComIdInexistente()
        {
            //Arrage
            var idInexistente = 999;
            //Act + Assert
            Assert.Throws<KeyNotFoundException>(() => _animalService.ObterAnimalPorId(idInexistente));
        }

        [Fact]
        public void DeveRetornarExcecaoAoTentarAcessarListaVaziaDeAnimais()
        {
            //Act + Assert
            Assert.Throws<InvalidOperationException>(() => _animalService.ObterTodosAnimais());
        }
        
        [Fact]
        public void DeveRetornarExcecaoAoTentarRegistrarVacinacaoNula()
        {
            // Arrage
            var animal = new Animal("Rex", "Labrador", "João");
            Vacinacao vacinacaoNula = null;
            // Act
            _animalService.CadastrarAnimal(animal);
            // Assert
            Assert.Throws<ArgumentNullException>(() => _animalService.RegistrarVacinacao(animal.Id, vacinacaoNula));
        }
    }
}