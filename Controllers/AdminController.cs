using AirTiquiciaTry.Models;
using AirTiquiciaTry.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirTiquiciaTry.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Aeropuertos()
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            return View(aeropuertos.GetAllAeropuertos());
        }

        public IActionResult AgregarAeropuerto()
        {
            return View();
        }


    }
}
