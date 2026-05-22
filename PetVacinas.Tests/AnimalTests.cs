using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Services;
using PetVacinas.Core.Models;
using PetVacinas.Core.Interfaces;
using Xunit;

namespace PetVacinas.Tests
{
    public class AnimalTests
    {
        private readonly IVacina _v1 = new Vacina("Antirrábica", "Sanofi Pasteur");
        private readonly IVacina _v2 = new Vacina("Vacina Multipla", "Fundação Butantan");

        private readonly IAnimal _a1 = new Animal("Rex", "Labrador", "João");
        private readonly IAnimal _a2 = new Animal("Biscoito", "Caramelo", "Sabrina");
        private readonly IAnimal _a3 = new Animal("Dolly", "Vira-lata", "André");

        private readonly IVacinacao _vac1;
        private readonly IVacinacao _vac2;

        private readonly AnimalService _animalService;
        public AnimalTests()
        {
            _animalService = new AnimalService();
            _vac1 = new Vacinacao("Carlos", _v1);
            _vac2 = new Vacinacao("Jorge", _v2);
        }

        // Sucessos
        [Fact]
        public void DeveCadastrarAnimalComSucessoNoRepositorio()
        {
            //Arrage
            var animal = _a1;
            //Act
            var result = _animalService.CadastrarAnimal(animal);
            //Assert
            Assert.Equal(animal, result);
        }

        [Fact]
        public void DeveObterAnimalPeloSeuId()
        {
            //Arrage
            var animal = _a2;
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
            var animal = _a3;
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
            var animal1 = _a1;
            var animal2 = _a2;
            var animal3 = _a3;
            //Act
            _animalService.CadastrarAnimal(animal1);
            _animalService.CadastrarAnimal(animal2);
            _animalService.CadastrarAnimal(animal3);
            var result = _animalService.ObterTodosAnimais();
            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count());
            Assert.Contains(result, a => a.Nome == "Rex");
            Assert.Contains(result, a => a.Nome == "Biscoito");
            Assert.Contains(result, a => a.Nome == "Dolly");
        }

        [Fact]
        public void DeveRegistrarVacinacaoComSucessoNoAnimal()
        {
            //Arrange
            var animal = _a3;
            var vacinacao = _vac1;

            //Act
            _animalService.CadastrarAnimal(animal);
            var result = _animalService.RegistrarVacinacao(animal.Id, vacinacao);

            //Assert
            Assert.Equal(vacinacao, result);
        }
        
        [Fact] 
        public void DeveMostrarHistoricoDeVacinacoesDoAnimalComVacinacoesRegistradas()
        {
            //Arrange
            var animal = _a2;
            var vacinacao1 = _vac1;
            var vacinacao2 = _vac2;

            //Act
            _animalService.CadastrarAnimal(animal);
            _animalService.RegistrarVacinacao(animal.Id, vacinacao1);
            _animalService.RegistrarVacinacao(animal.Id, vacinacao2);
            var result = _animalService.ObterHistoricoDeVacinacoes(animal.Id);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, v => v.Vacina == _v1);
            Assert.Contains(result, v => v.Vacina == _v2);
        }

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
            var animal = _a1;
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
            var animal = _a1;
            Vacinacao vacinacaoNula = null;
            // Act
            _animalService.CadastrarAnimal(animal);
            // Assert
            Assert.Throws<ArgumentNullException>(() => _animalService.RegistrarVacinacao(animal.Id, vacinacaoNula));
        }
    }
}