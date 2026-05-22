using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;

namespace PetVacinas.Core.Models
{
    public class Vacina : IVacina
    {
        private static int _contadorId = 0;

        public int Id { get; }
        public string Nome  {get; } = string.Empty;
        public string Fabricante { get; } = string.Empty;

        public Vacina(string nome, string fabricante)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da vacina não pode ser vazio.", nameof(nome));
            if (string.IsNullOrWhiteSpace(fabricante))
                throw new ArgumentException("O nome do fabricante não pode ser vazio.", nameof(fabricante));

            Id = ++_contadorId;
            Nome = nome;
            Fabricante = fabricante;
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} | Fabricante: {Fabricante}";
        }
    }
}