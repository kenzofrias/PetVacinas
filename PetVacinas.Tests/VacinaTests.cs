using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;
using PetVacinas.Core.Models;
using PetVacinas.Core.Services;
using Xunit;

namespace PetVacinas.Tests
{
    public class VacinaTests
    {
        private readonly IVacina _v1 = new Vacina("Antirrábica", "Sanofi Pasteur");
        private readonly IVacina _v2 = new Vacina("Vacina Multipla", "Fundação Butantan");

        private readonly VacinaService _vacinaService;
        public VacinaTests()
        {
            _vacinaService = new VacinaService();
        }

        // Sucessos
        [Fact]
        public void DeveCadastrarVacinasComSucessoNoRepositorio()
        {
            //Arrange
            var vacina1 = _v1;
            var vacina2 = _v2;

            //Act 
            var result1 = _vacinaService.CadastrarVacina(vacina1);
            var result2 = _vacinaService.CadastrarVacina(vacina2);

            //Assert
            Assert.Equal(vacina1, result1);
            Assert.Equal(vacina2, result2);
        }

        [Fact]
        public void DeveObterVacinaPorId()
        {
            //Arrange
            var vacina = _v2;
            var vacinaCadastrada = _vacinaService.CadastrarVacina(vacina);

            //Act
            var result = _vacinaService.ObterVacinaPorId(vacinaCadastrada.Id);

            //Assert
            Assert.Equal(vacina, result);
        }

        [Fact]
        public void DeveObterTodasAsVacinasCadastradas()
        {
            //Arrange
            var vacina1 = _v1;
            var vacina2 = _v2;

            //Act
            _vacinaService.CadastrarVacina(vacina1);
            _vacinaService.CadastrarVacina(vacina2);

            //Assert
            Assert.NotEmpty(_vacinaService.ObterTodasVacinas());
            Assert.Equal(2, _vacinaService.ObterTodasVacinas().Count());
            Assert.Contains(_vacinaService.ObterTodasVacinas(), v => v.Nome == "Antirrábica");
            Assert.Contains(_vacinaService.ObterTodasVacinas(), v => v.Nome == "Vacina Multipla");
        }

        // Falhas
        [Fact]
        public void DeveRetornarExcecaoAoTentarCadastrarVacinaNula()
        {
            //Arrange
            IVacina vacinaNula = null;

            //Act + Assert
            Assert.Throws<ArgumentNullException>(() => _vacinaService.CadastrarVacina(vacinaNula));
        }

        [Fact]
        public void DeveRetornarExcecaoAoTentarCadastrarVacinaJaExistente()
        {
            //Arrange
            var vacina = _v1;

            //Act
            _vacinaService.CadastrarVacina(vacina);

            // Assert
            Assert.Throws<InvalidOperationException>(() => _vacinaService.CadastrarVacina(vacina));
        }

        [Fact]
        public void DeveRetornarExcecaoAoTentarObterVacinaPorIdInexistente()
        {
            // Arrange
            int id = 10;

            // Act + Assert
            Assert.Throws<KeyNotFoundException>(() => _vacinaService.ObterVacinaPorId(id));
        }
        
        [Fact]
        public void DeveRetornarExcecaoAoTentarObterTodasAsVacinasSemNenhumaCadastrada()
        {
            //AAA
            Assert.Throws<InvalidOperationException>(() => _vacinaService.ObterTodasVacinas());
        }
    }
}