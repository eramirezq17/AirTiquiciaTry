using AirTiquiciaTry.Models;
using AirTiquiciaTry.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirTiquiciaTry.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }

        /**************************ACCIONES AEROPUERTOS********************************************************/

        [Authorize(Roles = "admin")]
        public IActionResult Aeropuertos()
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            return View(aeropuertos.GetAllAeropuertos());
        }

        [Authorize(Roles = "admin")]
        public IActionResult AgregarAeropuerto()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult ProcessAgregarAeropuerto(AeropuertosModel aeropuerto)
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            aeropuertos.Insert(aeropuerto);
            return View("Aeropuertos", aeropuertos.GetAllAeropuertos());
        }

        [Authorize(Roles = "admin")]
        public IActionResult BuscarAeropuertos(string searchTerm)
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            List<AeropuertosModel> aeropuertosList = aeropuertos.SearchAeropuertos(searchTerm);
            return View("Aeropuertos", aeropuertosList);
        }

        [Authorize(Roles = "admin")]
        public IActionResult DetallesAeropuerto(string cod)
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            AeropuertosModel foundAeropuerto = aeropuertos.GetAeropuertoById(cod);
            return View(foundAeropuerto);
        }

        [Authorize(Roles = "admin")]
        public IActionResult EditarAeropuerto(string cod)
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            AeropuertosModel foundAeropuerto = aeropuertos.GetAeropuertoById(cod);
            return View("EditarAeropuertoForm", foundAeropuerto);
        }

        [Authorize(Roles = "admin")]
        public IActionResult ProcessEditarAeropuerto(AeropuertosModel aeropuerto)
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            aeropuertos.Update(aeropuerto);
            return View("Aeropuertos", aeropuertos.GetAllAeropuertos());
        }

        [Authorize(Roles = "admin")]
        public IActionResult DeleteAeropuerto(String cod)
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            AeropuertosModel aeropuerto = aeropuertos.GetAeropuertoById(cod);
            aeropuertos.Delete(aeropuerto);
            return View("Aeropuertos", aeropuertos.GetAllAeropuertos());
        }

   

        /**************************ACCIONES AVIONES********************************************************/
        [Authorize(Roles = "admin")]
        public IActionResult Aviones()
        {
            AvionesDAO aviones = new AvionesDAO();
            return View(aviones.GetAllAviones());
        }


        [Authorize(Roles = "admin")]
        public IActionResult DeleteAvion(int cod)
        {
            AvionesDAO aviones = new AvionesDAO();
            AvionesModel avion = aviones.GetAvionById(cod);
            aviones.Delete(avion);
            return View("Aviones", aviones.GetAllAviones());
        }

        [Authorize(Roles = "admin")]
        public IActionResult AgregarAvion()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult ProcessAgregarAvion(AvionesModel avion)
        {
            AvionesDAO aviones = new AvionesDAO();
            aviones.Insert(avion);
            return View("Aviones", aviones.GetAllAviones());
        }

        [Authorize(Roles = "admin")]
        public IActionResult DetallesAvion(int cod)
        {
            AvionesDAO aviones = new AvionesDAO();
            AvionesModel foundAvion = aviones.GetAvionById(cod);
            return View(foundAvion);
        }

        [Authorize(Roles = "admin")]
        public IActionResult EditarAvion(int cod)
        {
            AvionesDAO aviones = new AvionesDAO();
            AvionesModel foundAvion = aviones.GetAvionById(cod);
            return View("EditarAvionForm", foundAvion);
        }

        [Authorize(Roles = "admin")]
        public IActionResult ProcessEditarAvion(AvionesModel avion)
        {
            AvionesDAO aviones = new AvionesDAO();
            aviones.Update(avion);
            return View("Aviones", aviones.GetAllAviones());
        }

        [Authorize(Roles = "admin")]
        public IActionResult BuscarAviones(string searchTerm)
        {
            AvionesDAO aviones = new AvionesDAO();
            List<AvionesModel> avionesList = aviones.SearchAviones(searchTerm);
            return View("Aviones", avionesList);
        }

        /**************************ACCIONES VUELOS********************************************************/
       
        [Authorize(Roles = "admin")]
        public IActionResult Vuelos()
        {
            VuelosDAO vuelos = new VuelosDAO();
            return View(vuelos.GetAllVuelos());
        }

        [Authorize(Roles = "admin")]
        public IActionResult AgregarVuelo()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult ProcessAgregarVuelo(VuelosModel vuelo)
        {
            VuelosDAO vuelos = new VuelosDAO();
            vuelos.Insert(vuelo);
            return View("Vuelos", vuelos.GetAllVuelos());
        }

        [Authorize(Roles = "admin")]
        public IActionResult DetallesVuelo(string cod)
        {
            VuelosDAO vuelos = new VuelosDAO();
            VuelosModel foundVuelo = vuelos.GetVueloById(cod);
            return View(foundVuelo);
        }

    }



}
