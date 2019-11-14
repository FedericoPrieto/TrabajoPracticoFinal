using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RapiTurnos.Models;
using RapiTurnosDTO.DTOs;

namespace RapiTurnos.DTOs
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {


            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SubRubros, SubRubrosDTO>().ReverseMap();
                cfg.CreateMap<Rubros, RubrosDTO>().ReverseMap();
                cfg.CreateMap<PersonasServicios, PersonasServiciosDTO>().ReverseMap();
                cfg.CreateMap<Personas, PersonasDTO>().ReverseMap();
                cfg.CreateMap<Localidades, LocalidadesDTO>().ReverseMap();
                cfg.CreateMap<EmpresasServicios, EmpresasServiciosDTO>().ReverseMap();
                cfg.CreateMap<Empresas, EmpresasDTO>().ReverseMap();
                cfg.CreateMap<DuracionTurnos, DuracionTurnosDTO>().ReverseMap();
            });


           
                

        








        }
    }
}
