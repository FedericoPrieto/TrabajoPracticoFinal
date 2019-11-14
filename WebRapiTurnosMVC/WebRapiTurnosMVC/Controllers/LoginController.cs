using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RapiTurnosDTO.DTOs;
using RestSharp;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace WebRapiTurnosMVC.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
                //Pantalla principal
                return View();

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UsuariosDTO usuariosDTO)
        {
            //usar en la view un validationsummary
                //Submit
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

                string sMailInput;
                string sPasswordInput;
                string sMailBase;
                string sPasswordBase;
                string sNombreBase;
                string sIdEmpresa;


          

                sMailInput = usuariosDTO.Mail;
                sPasswordInput = usuariosDTO.Password;


                var cliente = new RestSharp.RestClient("https://localhost:44331/api/Empresas/GetEmpresasByMail/" + sMailInput);

                var request = new RestSharp.RestRequest(RestSharp.Method.GET);

                //var dto = cliente.Execute<EmpresasDTO>(request, Method.OPTIONS).Data; romero porque no me mapeo el objeto tuve que sacarlo asi

                var dto = cliente.Execute<object>(request, Method.GET).Data;


                var x = JsonConvert.SerializeObject(dto);
                var jsonObj = JsonConvert.DeserializeObject<EmpresasDTO>(x);

                ViewBag.MensajeLogin = "Login Erroneo";
                if (jsonObj != null)
                {
                    sMailBase = jsonObj.Email;
                    sPasswordBase = jsonObj.Password;
                    sNombreBase = jsonObj.Nombre;
                    sIdEmpresa = jsonObj.IdEmpresa.ToString();

                    if ((sMailBase == sMailInput) && (sPasswordBase == sPasswordInput))
                    {
                        ViewBag.MensajeLogin = "Login Exitoso";
                        await Autenticar(sMailInput, sNombreBase, sIdEmpresa);

                        return RedirectToAction("Edit", "Empresas");

                    }
                    else
                    {
                        ViewBag.MensajeLogin = "Login Erroneo";
                    }

                }
                return View();

        }

        private async Task Autenticar(string email, string nombre, string IdEmpresa)
        {


            //agrego toda la info adicional que necesito del login
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, email),
                new Claim(ClaimTypes.Name, nombre),
                new Claim(ClaimTypes.Hash, IdEmpresa),
                new Claim(ClaimTypes.Role, "Adm")
            };

            //nueva forma
            var claimsIdentity = new ClaimsIdentity(claims, "login");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(30),
                IsPersistent = true,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        public IActionResult LoginPost()
            //public IActionResult LoginPost(EmpresasDTO empresasDTO)
        {

            string sMail;
            sMail = "ss";
            //sMail = empresasDTO.Email;

            //var client = new RestClient("https://localhost:44331/api/Empresas/" + sMail);
            //client.AddDefaultHeader("Content-type", "application/json");
            //var request1 = new RestRequest("https://localhost:44331/api/Empresas/" + sMail, Method.OPTIONS);
            //request1.RequestFormat = DataFormat.Json;

            //request1.AddJsonBody(empresasDTO);

            //var response = client.Execute(request1);


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
    }
}