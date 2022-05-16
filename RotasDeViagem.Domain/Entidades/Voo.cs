using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotasDeViagem.Domain.Entidades
{
    public sealed class Voo
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public List<Escala> Escalas { get; set; }
        public string Valor { get; set; }
        
    }
}
