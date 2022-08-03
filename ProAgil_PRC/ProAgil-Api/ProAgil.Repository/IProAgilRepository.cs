using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync(); 

        Task<Evento[]> GetAllEventoAsynByTema(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsyn(bool includePalestrantes);
        Task<Evento> GetAllEventoAsynById(int EventoId, bool includePalestrantes);
        Task<Palestrante[]> GetAllPalestranteAsynByName(string name, bool includeEventos);
        Task<Palestrante> GetAllPalestranteAsync(int PalestranteId, bool includeEventos);
    }
}