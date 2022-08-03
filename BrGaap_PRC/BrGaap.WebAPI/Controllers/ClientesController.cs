using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BrGaap.WebAPI.Model; 
using BrGaap.WebAPI.DTO;
using BrGaap.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BrGaap.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {       
        private readonly DataContext _db;
        public ClientesController(DataContext context)
        {
            this._db = context;             
        }       
         
          
        [HttpGet]
        public ActionResult<ClientesDTO> Get()
        {
            var cliente = new ClientesDTO();
            cliente.clientes = _db.Clientes.ToList();           
            return cliente ;
        } 

        [HttpGet("GetClientes")]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            return _db.Clientes.ToList();
        }

        [HttpGet("{cnpj}")]
        public ActionResult<Cliente> Get(string cnpj)
        {
            return _db.Clientes.Where(x => x.Cnpj == cnpj).FirstOrDefault();
        }
 
        [HttpPost]
        public bool  Post(Cliente cliente)
        {
            try
            {
                var cnpj = _db.Clientes.Where(x => x.Cnpj == cliente.Cnpj).FirstOrDefault();
                if(cnpj == null)
                {                    
                    _db.Clientes.Add(cliente);
                    _db.SaveChanges();
                    return true;
                }
                return false;   
            }
            catch (System.Exception)
            {                
                throw;
            }
        }
 
        [HttpPut("{id}")]
        public bool Put(int id, Cliente atualizarCliente)
        {
            try
            {
                var  cliente = _db.Clientes.Find(id);
                if(cliente.Cnpj == atualizarCliente.Cnpj)
                {                
                    cliente.Bairro = atualizarCliente.Bairro;
                    cliente.Cep = atualizarCliente.Cep;
                    cliente.Cidade = atualizarCliente.Cidade;
                    cliente.NomeCliente = atualizarCliente.NomeCliente;
                    cliente.Cnpj = atualizarCliente.Cnpj;
                    cliente.Logradouro = atualizarCliente.Logradouro;
                    cliente.Estado = atualizarCliente.Estado;

                    _db.Entry(cliente).State = EntityState.Modified;
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {                
                throw;
            }
        }
 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var  cliente = _db.Clientes.Find(id);
            _db.Clientes.Remove(cliente);
            _db.SaveChanges();
        }
    }
}
