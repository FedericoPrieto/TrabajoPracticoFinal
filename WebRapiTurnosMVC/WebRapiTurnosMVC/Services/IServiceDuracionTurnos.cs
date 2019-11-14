using System.Collections.Generic;
using RapiTurnosDTO.DTOs;

namespace WebRapiTurnosMVC.Services
{
    public interface IServiceDuracionTurnos
    {
        List<DuracionTurnosDTO> GetDuracionTurnosAll();
    }
}