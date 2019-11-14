using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using RapiTurnosDTO.DTOs;

namespace WebRapiTurnosMVC.Services
{
    public interface IServiceSubRubros
    {
        List<SubRubrosDTO> GetSubRubrosByRubroID(int RubroID);
        List<SelectListItem> GetSubRubrosAllConvertToselectItem(int RubroID);

    }

    

}