using RotasDeViagem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotasDeViagem.Application.Interfaces
{
    public interface IVooService
    {
        List<VooDTO> GetVoos();
        VooDTO GetById(int id);
        public List<VooDTO> GetMelhorRota(string origem, string destino);
        void Create (Voo2DTO vooDTO);
        void Update(VooDTO vooDTO);
        void Remove(int id);
    }
}
