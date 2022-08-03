using System;
using VagaBackendTeste.Domain.Entity;

namespace VagaBackendTeste.Business
{
    public class MarcaCarroBusiness
    {
        public Marca UpperMarca(Marca marca) 
        {
            marca.NomeMarca = marca.NomeMarca.ToUpper();
            return marca;
        } 
        public bool QtdCaractereMarca(Marca marca)
        {
            if(marca.NomeMarca.Length <= 50)
            {
                return true;
            }
            return false;
        }
    }
}
