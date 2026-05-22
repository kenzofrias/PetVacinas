using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;

namespace PetVacinas.Core.Models
{
    public class VacinaRepositorio : IVacinaRepositorio
    {
        private readonly Dictionary<int, IVacina> _vacinas;
        public VacinaRepositorio()
        {
            _vacinas = new Dictionary<int, IVacina>();
        }
        public IVacina Adicionar(IVacina vacina)
        {
            if (vacina == null)
                throw new ArgumentNullException("Vacina não pode ser nula.", nameof(vacina));
            if (_vacinas.ContainsKey(vacina.Id))
                throw new InvalidOperationException($"Vacina com ID {vacina.Id} já existe.");
            _vacinas[vacina.Id] = vacina;
            return vacina;
        }

        public IVacina ObterPorId(int id)
        {
            if (_vacinas.TryGetValue(id, out var vacina))
                return vacina;
            
            throw new KeyNotFoundException($"Vacina com ID {id} não encontrada.");
        }

        public IEnumerable<IVacina> ObterTodas()
        {
            if (_vacinas.Count == 0)
                throw new InvalidOperationException("Nenhuma vacina cadastrada.");
            return _vacinas.Values;
        }
    }
}