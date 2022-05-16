using RotasDeViagem.Domain.Entidades;
using RotasDeViagem.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotasDeViagem.Infra.Data
{
    public class VooRepository : IVooRepository
    {
        public Voo GetById(int id)
        {
            return new LendoMeuDB().ListarBD().FirstOrDefault(t => t.Id == id);
        }
        public List<Voo> GetVoos()
        {
            return new LendoMeuDB().ListarBD(); 
        }
        public List<Voo> Create(Voo voo)
        {
            new LendoMeuDB().Create(voo);
            return new LendoMeuDB().ListarBD();
        }
        public List<Voo> Remove(Voo voo)
        {
            new LendoMeuDB().Remove(voo);            
            return new LendoMeuDB().ListarBD();
        }
        public List<Voo> Update(Voo voo)
        {
            new LendoMeuDB().Update(voo);
            return new LendoMeuDB().ListarBD();
        }
    }
}
