using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using RapiTurnosDTO.DTOs;

namespace WebRapiTurnosMVC.Services
{
    public interface IServiceRubros
    {
        List<RubrosDTO> GetRubrosAll();
        List<SelectListItem> GetRubrosAllConvertToselectItem();
    }
}