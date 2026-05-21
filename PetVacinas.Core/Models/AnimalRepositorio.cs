using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;

namespace PetVacinas.Core.Models
{
    public class AnimalRepositorio : IAnimalRepositorio
    {
        private readonly Dictionary<int, IAnimal> _animais;

        public AnimalRepositorio()
        {
            _animais = new Dictionary<int, IAnimal>();
        }

        public void Adicionar(IAnimal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal));

            if (_animais.ContainsKey(animal.Id))
                throw new InvalidOperationException($"Um animal com o ID {animal.Id} já existe.");

            _animais[animal.Id] = animal;
            Console.WriteLine($"Cadastro de {animal.Nome} realizado com sucesso.");
        }

        public IAnimal ObterPorId(int id)
        {
            if (_animais.TryGetValue(id, out var animal))
                return animal;

            throw new KeyNotFoundException($"Nenhum animal encontrado com o ID {id}.");
        }

        public IEnumerable<IAnimal> ObterTodos()
        {
            if (_animais.Count == 0)
                throw new InvalidOperationException("Nenhum animal cadastrado.");
            return _animais.Values;            
        }
    }
}