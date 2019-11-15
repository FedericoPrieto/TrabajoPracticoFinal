using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RapiTurnosDTO.DTOs;
using RestSharp;
using WebRapiTurnosMVC.Services;

namespace WebRapiTurnosMVC.Controllers
{
    public class EmpresasController : Controller
    {

        private readonly IServiceRubros _serviceRubros;
        private readonly IServiceSubRubros _serviceSubRubros;

        public EmpresasController(IServiceRubros serviceRubros, IServiceSubRubros serviceSubRubros)
        {
            this._serviceRubros = serviceRubros;
            this._serviceSubRubros = serviceSubRubros;

        }


        public IActionResult Index()
        {

            var idEmpresa = User.FindFirst(ClaimTypes.Hash).Value;

            if ( Int32.Parse(idEmpresa) > 0) 
            {
                return RedirectToAction( "Edit");
            }
            
            
            var ListOfRubros = _serviceRubros.GetRubrosAll();
            //consumo la webapi para obtener los dtos
            var cliente = new RestSharp.RestClient("https://localhost:44331/api/Empresas/" + idEmpresa);

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);
            
            var dto = cliente.Execute<EmpresasDTO>(request).Data;
            ViewBag.Rubros = ListOfRubros;
            return View("Create",dto);

        }


        [AllowAnonymous]
        
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("/Empresas/GetSubRubrosForPartialView/{id}")]
        public IActionResult GetSubRubrosForPartialView(int id)
        {
            var LisOfSubRubros =_serviceSubRubros.GetSubRubrosByRubroID(id);
            
            ViewBag.SubRubros = LisOfSubRubros;

            return View("GetSubRubrosForPartialView");
        }



        [HttpGet]
        public IActionResult Edit()
        {



            var idEmpresa = User.FindFirst(ClaimTypes.Hash).Value;
            var ListOfRubros = _serviceRubros.GetRubrosAll();

            //consumo la webapi para obtener los dtos
            var cliente = new RestSharp.RestClient("https://localhost:44331/api/Empresas/" + idEmpresa);

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            var dto = cliente.Execute<EmpresasDTO>(request).Data;


            var selectListItems = new List<SelectListItem>();

            foreach (var item in ListOfRubros)
            {
                //convierto cada dto en un selectItem para usarlo en un dropdown(combo)
                selectListItems.Add(new SelectListItem
                {
                    Text = item.Descripcion,
                    Value = item.RubroId.ToString()
                });
            }
            
            ViewBag.Rubros = selectListItems;
            return View(dto);
        }


        [AllowAnonymous]
        [HttpGet]

        public IActionResult Create()
        {
         
            var dtoEmpresa = new EmpresasDTO();
            dtoEmpresa.RubroId = 1;
            var selectListItems = _serviceRubros.GetRubrosAllConvertToselectItem();
            var selectListItemsSubRubros = _serviceSubRubros.GetSubRubrosAllConvertToselectItem(dtoEmpresa.RubroId);
            ViewBag.Rubros = selectListItems;
            ViewBag.SubRubros = selectListItemsSubRubros;

            return View(dtoEmpresa);
        }


      


        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreatePost(EmpresasDTO empresasDTO)
        {

            
           empresasDTO.RubroId = 1;
            empresasDTO.EstadoActual = 1;
            empresasDTO.Latitud = "1";
            empresasDTO.Longitud = "1";
            empresasDTO.IdLocalidad = 1;
            empresasDTO.FechaAlta = DateTime.Today;




            var client = new RestClient("https://localhost:44331/api/Empresas");
            client.AddDefaultHeader("Content-type", "application/json");
            var request1 = new RestRequest("https://localhost:44331/api/Empresas", Method.POST);
            request1.RequestFormat = DataFormat.Json;

            request1.AddJsonBody(empresasDTO);

            var response = client.Execute(request1);

            
            return RedirectToAction("Index","Home");

        }



        [HttpPost]
        public IActionResult EditPut(EmpresasDTO empresasDTO)
        {

            //empresasDTO.RubroId = 1;
            empresasDTO.EstadoActual = 1;
            empresasDTO.Latitud = "1";
            empresasDTO.Longitud = "1";
            empresasDTO.IdLocalidad = 1;
            empresasDTO.FechaAlta = DateTime.Today;




            var client = new RestClient("https://localhost:44331/api/Empresas/" + empresasDTO.IdEmpresa);
            client.AddDefaultHeader("Content-type", "application/json");
            var request1 = new RestRequest("https://localhost:44331/api/Empresas/"  + empresasDTO.IdEmpresa, Method.POST);
            request1.RequestFormat = DataFormat.Json;

            request1.AddJsonBody(empresasDTO);

            var response = client.Execute(request1);


            return RedirectToAction( "Index","Home");

        }



    }
}