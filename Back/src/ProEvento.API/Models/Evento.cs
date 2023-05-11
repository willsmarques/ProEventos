using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEvento.API.Models
{
    public class Evento
    {
        public int eventoId { get; set; }
        public string local { get; set; }
        public string dataEvento { get; set; }
        public string tema { get; set; }
        public int qtdPessoa { get; set; }
        public string lote { get; set; }
        public string imagemUrl { get; set; }
        
    }
}