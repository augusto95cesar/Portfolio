using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;
        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return ( await _context.SaveChangesAsync() > 0);
        }        
        public async Task<Evento[]> GetAllEventoAsyn(bool includePalestrantes =false)
        {
             IQueryable<Evento> query = _context.Eventos
                                        .Include(c => c.Lotes)
                                        .Include(c => c.RedeSociais);
            if(includePalestrantes){
                query = query.Include(pe => pe.PalestranteEventos)
                             .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(dt => dt.DataEvento);

            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventoAsynByTema(string tema, bool includePalestrantes = false) 
        {
             IQueryable<Evento> query = _context.Eventos
                                        .Include(c => c.Lotes)
                                        .Include(c => c.RedeSociais);
            if(includePalestrantes){
                query = query.Include(pe => pe.PalestranteEventos)
                             .ThenInclude(p => p.Palestrante);
            }

            //query = query.OrderByDescending(dt => dt.DataEvento).Where(t => t.Tema.Contains(tema));
            query = query.OrderByDescending(dt => dt.DataEvento)
                         .Where(t => t.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetAllEventoAsynById(int eventoId, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Eventos
                                        .Include(c => c.Lotes)
                                        .Include(c => c.RedeSociais);
            if(includePalestrantes){
                query = query.Include(pe => pe.PalestranteEventos)
                             .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(dt => dt.DataEvento)
                         .Where(i => i.EventoId == eventoId);

            return await query.FirstOrDefaultAsync();
        }
         public async Task<Palestrante> GetAllPalestranteAsync(int palestranteId, bool includeEventos =false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                            .Include(c => c.RedeSociais);
            if(includeEventos){
                query = query.Include(pe => pe.PalestranteEventos)
                             .ThenInclude(e => e.Evento);
            }
            query = query.OrderBy(n => n.Nome)
                         .Where(i => i.Id == palestranteId);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> GetAllPalestranteAsynByName(string name, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                            .Include(c => c.RedeSociais);
            if(includeEventos){
                query = query.Include(pe => pe.PalestranteEventos)
                             .ThenInclude(e => e.Evento);
            }
            //query = query.Where(n => n.Nome == name);
            query = query.Where(n => n.Nome.ToLower().Contains(name.ToLower()));
                         
            return await query.ToArrayAsync();            
        }       
    }
}