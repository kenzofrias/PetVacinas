using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;

namespace PetVacinas.Core.Models
{
    public class VacinacaoRepositorio : IVacinacaoRepositorio
    {
        private readonly Dictionary<int, IVacinacao> _aplicacoes;
        public VacinacaoRepositorio()
        {
            _aplicacoes = new Dictionary<int, IVacinacao>();
        }
        public IVacinacao Adicionar(IVacinacao vacinacao)
        {
            if (vacinacao == null)
                throw new ArgumentNullException("Vacinação não pode ser nula.", nameof(vacinacao));

            if (_aplicacoes.ContainsKey(vacinacao.Id))
                throw new InvalidOperationException($"Uma vacinação com o ID {vacinacao.Id} já existe.");

            _aplicacoes[vacinacao.Id] = vacinacao;
            return vacinacao;
        }

        public IVacinacao ObterPorId(int id)
        {
            if (_aplicacoes.TryGetValue(id, out var vacinacao))
                return vacinacao;

            throw new KeyNotFoundException($"Nenhuma vacinação encontrada com o ID {id}.");
        }

        public IEnumerable<IVacinacao> ObterTodas()
        {
            if (_aplicacoes.Count == 0)
                throw new InvalidOperationException("Nenhuma vacinação cadastrada.");
                
            return _aplicacoes.Values;
        }
    }
}