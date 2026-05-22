using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetVacinas.Core.Interfaces;
using PetVacinas.Core.Models;

namespace PetVacinas.Core.Services
{
    public class VacinaService : IVacinaService
    {
        private readonly IVacinaRepositorio _vacinaRepositorio;
        public VacinaService()
        {
            _vacinaRepositorio = new VacinaRepositorio();
        }
        public IVacina CadastrarVacina(IVacina vacina)
        {
            return _vacinaRepositorio.Adicionar(vacina);
        }

        public IEnumerable<IVacina> ObterTodasVacinas()
        {
            return _vacinaRepositorio.ObterTodas();
        }

        public IVacina ObterVacinaPorId(int id)
        {
            return _vacinaRepositorio.ObterPorId(id); 
        }
    }
}