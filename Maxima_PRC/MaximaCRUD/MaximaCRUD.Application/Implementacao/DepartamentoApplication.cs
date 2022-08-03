using MaximaCRUD.Application.Interface;
using MaximaCRUD.Data;
using MaximaCRUD.Domain.Dtos; 
using MaximaCRUD.Repository;
using MaximaCRUD.Service.Map; 
using System.Collections.Generic;
using System.Linq;

namespace MaximaCRUD.Application.Implementacao
{
    public class DepartamentoApplication : IDepartamentoApplication
    {
        private readonly DepartamentoRepository _departamento;
        private readonly ProdutoRepository _prod;

        public DepartamentoApplication(DataContext context)
        {
            this._departamento = new DepartamentoRepository(context);
            this._prod = new ProdutoRepository(context);
        }

        public DepartamentoDto CreateDepartamento(CreateDepartamentoDto dp)
        {
           return _departamento.CreateDepartamento(dp.MapearDepartamento()).MapearDepartamentoDto(); 
        }

        public bool DeleteDepartamento(int id)
        {
            if(_prod.GetProdutosDepartamento(id).Count() != 0)
            {
                //Serviço de mesageria seria bem vindo - RabbitMQ por exemplo.
                return false;
            }
            return _departamento.DeleteDepartamento(id);
        }

        public DepartamentoDto GetDepartamento(string departamento)
        {
            return _departamento.GetDepartamento(departamento).MapearDepartamentoDto();
        }

        public List<DepartamentoDto> GetDepartamentos(int pagina, int quantidade)
        {
            return _departamento.GetDepartamentos(pagina, quantidade).MapearDepartamentoDto();
        }

        public bool UpdateDepartamento(DepartamentoDto dp)
        {
          return  _departamento.UpdateDepartamento(dp.MapearDepartamento()); 
        }
    }
}
