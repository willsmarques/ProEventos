using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventoPersistence :IEventoPersist
    {
        private readonly ProEventosContext _context;
        public EventoPersistence(ProEventosContext context)
        {
            _context = context; 
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; 
        }


        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);
            
            if(includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);
            }

            return await query.OrderBy(e => e.Id).AsNoTracking().ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
           IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);
            
            if(includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);
            }

            return await query.OrderBy(e => e.Id).AsNoTracking().Where(e => e.Tema.ToLower().Contains(tema.ToLower())).ToArrayAsync();
        }

        
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
           IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);
            
            if(includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);
            }

            return await query.OrderBy(e => e.Id).AsNoTracking().Where(e => e.Id == eventoId).FirstOrDefaultAsync();
        }

    }
}