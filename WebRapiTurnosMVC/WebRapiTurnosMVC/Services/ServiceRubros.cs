using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using RapiTurnosDTO.DTOs;
namespace WebRapiTurnosMVC.Services
{
    public class ServiceRubros : IServiceRubros
    {
        public List<RubrosDTO> GetRubrosAll()
        {
            var cliente = new RestSharp.RestClient("https://localhost:44331/api/Rubros");

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            var dtos = cliente.Execute<List<RubrosDTO>>(request).Data;
            return dtos;
            
        }
        
        public List<SelectListItem> GetRubrosAllConvertToselectItem()
        {
            var selectListItems = new List<SelectListItem>();
            var ListOfRubros = GetRubrosAll();
            //Usado para llenar dropdown(combo)

            foreach (var item in ListOfRubros)
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
