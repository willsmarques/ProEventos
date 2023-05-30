using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantesPersistence : IPalestrantePersist
    {
        private readonly ProEventosContext _context;
        public PalestrantesPersistence(ProEventosContext context)
        {
            this._context = context;
            
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
          IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);
            
            if(includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);
            }

            return await query.OrderBy(p => p.Id).AsNoTracking().ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);
            
            if(includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);
            }

            return await query.OrderBy(p => p.Id).AsNoTracking().Where(p => p.Nome.ToLower().Contains(nome.ToLower())).ToArrayAsync();

        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);
            
            if(includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);
            }

            return await query.OrderBy(p => p.Id).AsNoTracking().Where(p => p.Id == PalestranteId).FirstOrDefaultAsync();
        }
    }
}