using RotasDeViagem.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotasDeViagem.Domain.Interfaces.Repository
{
    public interface IVooRepository
    {
        List<Voo> GetVoos();
        Voo GetById(int id);

        List<Voo> Create(Voo voo);
        List<Voo> Update(Voo voo);
        List<Voo> Remove(Voo voo);
    }
}
