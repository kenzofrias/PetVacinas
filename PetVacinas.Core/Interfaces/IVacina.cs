using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVacinas.Core.Interfaces
{
    public interface IVacina
    {
        int Id { get; }
        string Nome { get; }
        string Fabricante { get; }
    }
}