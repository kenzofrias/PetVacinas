using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVacinas.Core.Interfaces
{
    public interface IVacinacao
    {
        int Id { get; }
        DateTime DataAplicacao { get; }
        string Responsavel { get; }
        IVacina Vacina { get; }
    }
}