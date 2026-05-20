using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;

namespace PetVacinas.Core.Models
{
    public class Vacinacao : IVacinacao
    {
        private static int _contadorId = 0;

        public int Id { get; }

        public DateTime DataAplicacao { get; }

        public string Responsavel { get; } = string.Empty;

        public IVacina Vacina { get; }

        public Vacinacao(string responsavel, IVacina vacina)
        {
            if (string.IsNullOrWhiteSpace(responsavel))
                throw new ArgumentException("O nome do responsável não pode ser vazio.", nameof(responsavel));
            if (vacina == null)
                throw new ArgumentNullException(nameof(vacina));

            Id = ++_contadorId;
            DataAplicacao = DateTime.Now;
            Responsavel = responsavel;
            Vacina = vacina;
        }

        public override string ToString()
        {
            return $"{DataAplicacao.Date.ToString("dd/MM/yyyy")} - {Vacina.Nome} | Responsável: {Responsavel}";
        }
    }
}