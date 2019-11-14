using RapiTurnosDTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRapiTurnosMVC.Services
{
    public class ServiceDuracionTurnos : IServiceDuracionTurnos
    {
        public List<DuracionTurnosDTO> GetDuracionTurnosAll()
        {
            
            var cliente = new RestSharp.RestClient("https://localhost:44331/api/DuracionTurnos");

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            var dtos = cliente.Execute<List<DuracionTurnosDTO>>(request).Data;
            return dtos;

        }
    }
}
