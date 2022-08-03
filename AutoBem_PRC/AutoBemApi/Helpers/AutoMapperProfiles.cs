using AutoBemApi.Dto;
using AutoBemApi.Model;
using AutoMapper; 
namespace AutoBemApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<"Model", "Dto">();
            CreateMap<Escola, EscolaDto>();
            CreateMap<Turma, TurmaDto>();
            CreateMap<Aluno, AlunoDto>();
            CreateMap<Frequencia, FrequenciaDto>();
        }
    }
}
