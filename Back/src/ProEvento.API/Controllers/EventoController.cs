using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEvento.API.Models;

namespace ProEvento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento =  new Evento[]{
                                new Evento(){
                                eventoId = 1,
                                tema = "Angular 11 e .NET 5",
                                local = "São Paulo" ,
                                lote = "1º Lote" ,
                                qtdPessoa = 250,
                                dataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                                imagemUrl = "foto.png"
                        },
                        new Evento(){
                                eventoId = 2,
                                tema = "Angular e suas Novidades",
                                local = "São Paulo",
                                lote = "2º Lote",
                                qtdPessoa = 350,
                                dataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                                imagemUrl = "foto1.png"
                    }

                };


        public EventoController()
        {
           
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;

        }

       [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where( evento=> evento.eventoId == id );

        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }

        
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }
    }
}