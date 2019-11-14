using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RapiTurnosDTO.DTOs;
using RestSharp;
using WebRapiTurnosMVC.Services;

namespace WebRapiTurnosMVC.Controllers
{
    public class EmpresasServiciosController : Controller
    {
        private readonly IServiceDuracionTurnos _serviceDuracionTurnos;

        public EmpresasServiciosController(IServiceDuracionTurnos serviceDuracionTurnos)
        {
            this._serviceDuracionTurnos = serviceDuracionTurnos;
        }

        public IActionResult Index()
        {
            var idEmpresa = User.FindFirst(ClaimTypes.Hash).Value;
            //consumo la webapi para obtener los dtos
            var cliente = new RestSharp.RestClient("https://localhost:44331/api/EmpresasServicios/GetEmpresasServiciosByEmpresa/" + idEmpresa);

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            var dtos = cliente.Execute<List<EmpresasServiciosDTO>>(request).Data;

            return View(dtos);
            
        }
        public IActionResult Create(EmpresasServiciosDTO empresasServiciosDTO)
        {

            ////consumo la webapi para obtener los dtos
            //var cliente = new RestSharp.RestClient("https://localhost:44331/api/EmpresasServicios/1");

            //var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            //var dtos = cliente.Execute<List<EmpresasServiciosDTO>>(request).Data;
            var idEmpresa = User.FindFirst(ClaimTypes.Hash).Value;
            empresasServiciosDTO.IdEmpresa = Int32.Parse(idEmpresa);

            return View(empresasServiciosDTO);

        }


        //public short IdServicio { get; set; }
        //public int IdEmpresa { get; set; }
        //public string Descripcion { get; set; }
        //public decimal PrecioSugerido { get; set; }
        //public short IdDuracionTurno { get; set; }
        //public DateTime FechaAlta { get; set; }

        //public async Task<IActionResult> Create2([Bind("Descripcion")] EmpresasServiciosDTO empresasServiciosDTO)
        //public async Task<IActionResult> Create2(string sDescripcion)

        public async Task<IActionResult> Create2(EmpresasServiciosDTO empresasServiciosDTO)
        {
            var idEmpresa = User.FindFirst(ClaimTypes.Hash).Value;
            empresasServiciosDTO.IdEmpresa = Int32.Parse(idEmpresa);
            empresasServiciosDTO.FechaAlta = DateTime.Now;
            empresasServiciosDTO.IdDuracionTurno = 1;
            var client = new RestClient("https://localhost:44331/api/EmpresasServicios");
            client.AddDefaultHeader("Content-type", "application/json");
            var request1 = new RestRequest("https://localhost:44331/api/EmpresasServicios", Method.POST);
            request1.RequestFormat = DataFormat.Json;

            request1.AddJsonBody(empresasServiciosDTO);

            var response = client.Execute(request1);


            return RedirectToAction("Index");

            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ////consumo la webapi para obtener los dtos
            var cliente = new RestSharp.RestClient("https://localhost:44331/api/EmpresasServicios/" + id);

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            var dto = cliente.Execute<EmpresasServiciosDTO>(request).Data;

            var listaDuracionTurnos = _serviceDuracionTurnos.GetDuracionTurnosAll();

            var selectListItems = new List<SelectListItem>();

            foreach (var item in listaDuracionTurnos)
            {
                //convierto cada dto en un selectItem para usarlo en un dropdown(combo)
                selectListItems.Add(new SelectListItem
                {
                    Text = item.Descripcion,
                    Value = item.IdDuracionTurno.ToString()
                });
            }

            ViewBag.ListaDuracionTurnos = selectListItems;

            return View(dto);
        }


        [HttpPost]
        public IActionResult EditPost(EmpresasServiciosDTO empresasServiciosDTO)
        {
            var idEmpresa = User.FindFirst(ClaimTypes.Hash).Value;
            empresasServiciosDTO.IdEmpresa = Int32.Parse(idEmpresa);
            empresasServiciosDTO.FechaAlta = DateTime.Now;

            var client = new RestClient("https://localhost:44331/api/EmpresasServicios");
            client.AddDefaultHeader("Content-type", "application/json");
            var request1 = new RestRequest("https://localhost:44331/api/EmpresasServicios/" + empresasServiciosDTO.IdServicio, Method.PUT);
            request1.RequestFormat = DataFormat.Json;

            request1.AddJsonBody(empresasServiciosDTO);

            var response = client.Execute(request1);

            
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            
            ////consumo la webapi para obtener los dtos
            var cliente = new RestSharp.RestClient("https://localhost:44331/api/EmpresasServicios/" + id);

            var request = new RestSharp.RestRequest(RestSharp.Method.DELETE);

            var dto = cliente.Execute<DuracionTurnosDTO>(request).Data;

            return RedirectToAction("Index");

            //return View(dto);
        }

    }
}