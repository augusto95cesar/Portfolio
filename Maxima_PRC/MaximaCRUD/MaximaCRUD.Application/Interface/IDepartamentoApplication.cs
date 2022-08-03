using MaximaCRUD.Domain.Dtos;
using MaximaCRUD.Domain.Entity; 
using System.Collections.Generic; 

namespace MaximaCRUD.Application.Interface
{
    public interface IDepartamentoApplication
    {
        public List<DepartamentoDto> GetDepartamentos(int pagina, int quantidade);
        public DepartamentoDto GetDepartamento(string dp);
        public DepartamentoDto CreateDepartamento(CreateDepartamentoDto dp);
        public bool UpdateDepartamento(DepartamentoDto dp);
        public bool DeleteDepartamento(int id);
    }
}
