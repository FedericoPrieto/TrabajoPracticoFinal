using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RapiTurnosDTO.DTOs;
using RestSharp;

namespace WebRapiTurnosMVC.Controllers
{
    public class DuracionTurnosController : Controller
    {
        public IActionResult Index()
        {
            //consumo la webapi para obtener los dtos
            var cliente = new RestSharp.RestClient("https://localhost:44331/api/DuracionTurnos");

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            var dtos = cliente.Execute<List<DuracionTurnosDTO>>(request).Data;

            return View(dtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ////consumo la webapi para obtener los dtos
            //var cliente = new RestSharp.RestClient("https://localhost:44331/api/DuracionTurnos");

            //var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            //var dtos = cliente.Execute<List<DuracionTurnosDTO>>(request).Data;
            var dto = new DuracionTurnosDTO();

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ////consumo la webapi para obtener los dtos
            var cliente = new RestSharp.RestClient("https://localhost:44331/api/DuracionTurnos/" + id);

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            var dto = cliente.Execute<DuracionTurnosDTO>(request).Data;

            return View(dto);
        }

        [HttpPost]
        public IActionResult CreatePost(DuracionTurnosDTO duracionTurnosDTO)
        {


            var client = new RestClient("https://localhost:44331/api/DuracionTurnos");
            client.AddDefaultHeader("Content-type", "application/json");
            var request1 = new RestRequest("https://localhost:44331/api/DuracionTurnos", Method.POST);
            request1.RequestFormat = DataFormat.Json;

            request1.AddJsonBody(duracionTurnosDTO);

            var response = client.Execute(request1);


            //grabo!!!!
            ////consumo la webapi para obtener los dtos
            //var cliente = new RestSharp.RestClient("https://localhost:44331/api/DuracionTurnos");

            //var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            //var dtos = cliente.Execute<List<DuracionTurnosDTO>>(request).Data;\



            //consumo la webapi para obtener los dtos


            //como hago para simplemente ir al controlador INDEX nuevamente seria como hacer
            //un refresh aca quisiera algo como call IActionResult Index() ROMERO PREGUNTA EMILIANO

            //var cliente = new RestSharp.RestClient("https://localhost:44331/api/DuracionTurnos");

            //var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            //var dtos = cliente.Execute<List<DuracionTurnosDTO>>(request).Data;

            //return View("Index", dtos);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult EditPost(DuracionTurnosDTO duracionTurnosDTO)
        {


            var client = new RestClient("https://localhost:44331/api/DuracionTurnos");
            client.AddDefaultHeader("Content-type", "application/json");
            var request1 = new RestRequest("https://localhost:44331/api/DuracionTurnos/" + duracionTurnosDTO.IdDuracionTurno, Method.PUT);
            request1.RequestFormat = DataFormat.Json;

            request1.AddJsonBody(duracionTurnosDTO);

            var response = client.Execute(request1);


            //grabo!!!!
            ////consumo la webapi para obtener los dtos
            //var cliente = new RestSharp.RestClient("https://localhost:44331/api/DuracionTurnos");

            //var request = new RestSharp.RestRequest(RestSharp.Method.GET);

            //var dtos = cliente.Execute<List<DuracionTurnosDTO>>(request).Data;\



            //consumo la webapi para obtener los dtos


            //como hago para simplemente ir al controlador INDEX nuevamente seria como hacer
            //un refresh aca quisiera algo como call IActionResult Index() ROMERO PREGUNTA EMILIANO

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ////consumo la webapi para obtener los dtos
            var cliente = new RestSharp.RestClient("https://localhost:44331/api/DuracionTurnos/" + id);

            var request = new RestSharp.RestRequest(RestSharp.Method.DELETE);

            var dto = cliente.Execute<DuracionTurnosDTO>(request).Data;

            return RedirectToAction("Index");

            //return View(dto);
        }

    }
}