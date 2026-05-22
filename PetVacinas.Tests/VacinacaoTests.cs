using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;
using PetVacinas.Core.Models;
using Xunit;

namespace PetVacinas.Tests
{
    public class VacinacaoTests
    {
        private readonly IVacina _v1 = new Vacina("Antirrábica", "Sanofi Pasteur");
        private readonly IVacina _v2 = new Vacina("Vacina Multipla", "Fundação Butantan");
        private readonly IVacina _v3 = new Vacina("Antitetânica", "Anvisa");

        private readonly IVacinacaoRepositorio _vacinacaoRepositorio;
        public VacinacaoTests()
        {
            _vacinacaoRepositorio = new VacinacaoRepositorio();
        }

        // Sucessos
        [Fact]
        public void DeveAdicionarVacinacaoAoRepositorio()
        {
            // Arrange
            var vacina = _v1;
            var vacinacao = new Vacinacao("Carlos", vacina);

            // Act
            var result = _vacinacaoRepositorio.Adicionar(vacinacao);

            // Assert
            Assert.Equal(vacinacao, result);
        }

        [Fact]
        public void DeveObterVacinacaoPorId()
        {
            // Arrange
            var vacina = _v2;
            var vacinacao = new Vacinacao("Jorge", vacina);

            // Act 
            _vacinacaoRepositorio.Adicionar(vacinacao);

            // Assert
            Assert.Equal(vacinacao, _vacinacaoRepositorio.ObterPorId(vacinacao.Id));
        }

        [Fact]
        public void DeveObterTodasAsVacinacoes()
        {
            // Arrange
            var vacinacao1 = new Vacinacao("Carlos", _v1);
            var vacinacao2 = new Vacinacao("Jorge", _v2);
            var vacinacao3 = new Vacinacao("Maria", _v3);

            // Act
            _vacinacaoRepositorio.Adicionar(vacinacao1);
            _vacinacaoRepositorio.Adicionar(vacinacao2);
            _vacinacaoRepositorio.Adicionar(vacinacao3);

            // Assert
            Assert.NotEmpty(_vacinacaoRepositorio.ObterTodas());
            Assert.Equal(3, _vacinacaoRepositorio.ObterTodas().Count());
            Assert.Contains(_vacinacaoRepositorio.ObterTodas(), v => v.Responsavel == "Carlos" && v.Vacina.Nome == "Antirrábica");
            Assert.Contains(_vacinacaoRepositorio.ObterTodas(), v => v.Responsavel == "Jorge" && v.Vacina.Nome == "Vacina Multipla");
            Assert.Contains(_vacinacaoRepositorio.ObterTodas(), v => v.Responsavel == "Maria" && v.Vacina.Nome == "Antitetânica");
        }

        // Falha
        [Fact]
        public void DeveRetornarExcecaoAoTentarAdicionarVacinacaoNula()
        {
            // Arrange
            IVacinacao vacinacaoNula = null;

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => _vacinacaoRepositorio.Adicionar(vacinacaoNula));
        }

        [Fact]
        public void DeveRetornarExcecaoAoTentarAdicionarVacinacaoJaExistente()
        {
            // Arrange
            var vacinacao = new Vacinacao("Carlos", _v1);

            // Act
            _vacinacaoRepositorio.Adicionar(vacinacao);

            // Assert
            Assert.Throws<InvalidOperationException>(() => _vacinacaoRepositorio.Adicionar(vacinacao));
        }

        [Fact]
        public void DeveRetornarExcecaoAoTentarObterVacinacaoPorIdInexistente()
        {
            // Arrange
            int id = 1000;

            // Act + Assert
            Assert.Throws<KeyNotFoundException>(() => _vacinacaoRepositorio.ObterPorId(id));
        }

        [Fact]
        public void DeveRetornarExcecaoAoTentarObterVacinacoesComListaVazia()
        {
            //AAA
            Assert.Throws<InvalidOperationException>(() => _vacinacaoRepositorio.ObterTodas());
        }
    }
}