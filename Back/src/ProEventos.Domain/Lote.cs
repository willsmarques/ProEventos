using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Domain
{
    public class Lote
    {
        public int id {get;set;}
        public String Nome {get;set;}
        public Decimal Preco {get;set;}
        public DateTime? DataInicio {get;set;}
        public DateTime? DataFim {get;set;}
        public int Quantidade {get;set;}
        public int EventoId {get;set;}
        public Evento Evento {get;set;}
        
    }
}