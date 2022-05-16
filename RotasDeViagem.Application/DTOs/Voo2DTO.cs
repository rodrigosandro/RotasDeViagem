using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotasDeViagem.Application.DTOs
{
    public class Voo2DTO
    {
        [Required(ErrorMessage = "A Origem é Obrigatório")]
        public string Origem { get; set; }
        [Required(ErrorMessage = "O Destino é Obrigatório")]
        public string Destino { get; set; }
        public List<EscalaDTO> Escalas { get; set; }
        [Required(ErrorMessage = "O valor e Obrigatório")]
        public decimal Valor { get; set; }
    }
}
