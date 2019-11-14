using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using RapiTurnosDTO.DTOs;
namespace WebRapiTurnosMVC.Services
{
    public class ServiceSubRubros : IServiceSubRubros
    {

        public List<SubRubrosDTO> GetSubRubrosByRubroID(int RubroID)
        {
            var cliente = new RestSharp.RestClient("https://localhost:44331/api/SubRubros/GetSubRubrosByRubroID/" + RubroID);
            var request = new RestSharp.RestRequest(RestSharp.Method.GET);
            var dtos = cliente.Execute<List<SubRubrosDTO>>(request).Data;
            return dtos;
        }

        public List<SelectListItem> GetSubRubrosAllConvertToselectItem( int RubroID)
        {
            var selectListItems = new List<SelectListItem>();
            var ListOfSubRubros = GetSubRubrosByRubroID(RubroID);
            //Usado para llenar dropdown(combo)

            foreach (var item in ListOfSubRubros)
            {
                //convierto cada dto en un selectItem para usarlo en un dropdown(combo)
                selectListItems.Add(new SelectListItem
                {
                    Text = item.Descripcion,
                    Value = item.RubroId.ToString()
                });
            }
            return selectListItems;
        }
    }
}
