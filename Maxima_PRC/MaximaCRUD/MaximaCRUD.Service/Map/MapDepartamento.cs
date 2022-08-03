using MaximaCRUD.Domain.Dtos;
using MaximaCRUD.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaximaCRUD.Service.Map
{
    public static class MapDepartamento
    {
        public static List<DepartamentoDto> MapearDepartamentoDto(this List<Departamento> dp)
        {
            List<DepartamentoDto> dto = new List<DepartamentoDto>();
            foreach (var lista in dp)
            {
                DepartamentoDto departamento = new DepartamentoDto
                {
                    Departamento = lista.NomeDepartamento,
                    CodigoDepartamento = lista.Id.ToString()
                };

                dto.Add(departamento);
            }
            return dto;
        }
        public static DepartamentoDto MapearDepartamentoDto(this Departamento dp)
        {
            return new DepartamentoDto
            {
                Departamento = dp.NomeDepartamento,
                CodigoDepartamento = dp.Id.ToString()
            };
        }
        public static Departamento MapearDepartamento(this DepartamentoDto dp)
        {
            return new Departamento
            {
                Id = Convert.ToInt32(dp.CodigoDepartamento),
                NomeDepartamento = dp.Departamento
            };
        }

        public static Departamento MapearDepartamento(this CreateDepartamentoDto dp)
        {
            return new Departamento
            {
                NomeDepartamento = dp.Departamento               
            };
        }
    }
}
