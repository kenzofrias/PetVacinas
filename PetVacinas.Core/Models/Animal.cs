using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;

namespace PetVacinas.Core.Models
{
    public class Animal : IAnimal
    {
        private readonly Stack<IVacinacao> _vacinacoes;
        private static int _contadorId = 0;

        public int Id { get; }
        public string Nome { get; } = string.Empty;
        public string Raca { get; } = string.Empty;
        public string Dono { get; } = string.Empty;
        public IReadOnlyCollection<IVacinacao> Vacinacoes => _vacinacoes;

        public Animal(string nome, string raca, string dono)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do animal não pode ser vazio.", nameof(nome));
            if (string.IsNullOrWhiteSpace(raca)) 
                throw new ArgumentException("A raça do animal não pode ser vazia.", nameof(raca));
            if (string.IsNullOrWhiteSpace(dono)) 
                throw new ArgumentException("O nome do dono não pode ser vazio.", nameof(dono));

            Id = ++_contadorId;
            Nome = nome;
            Raca = raca;
            Dono = dono;
            _vacinacoes = new Stack<IVacinacao>();
        }

        public IVacinacao RegistrarVacinacaoAnimal(IVacinacao vacinacao)
        {
            if (vacinacao == null)
                throw new ArgumentNullException(nameof(vacinacao));

            _vacinacoes.Push(vacinacao);
            return vacinacao;
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} ({Raca}) | Dono: {Dono}";
        }
    }
}