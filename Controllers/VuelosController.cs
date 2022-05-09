using AirTiquiciaTry.Models;
using AirTiquiciaTry.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AirTiquiciaTry.Controllers
{
    public class VuelosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuscarVueloSencillo()
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            List<AeropuertosModel> listaAeropuertos = aeropuertos.GetAllAeropuertos();
            ViewBag.listaAeropuertos = new SelectList(listaAeropuertos, "cod_iata", "fullDesc");
            return View();
        }
        public IActionResult VuelosEncontrados(VuelosModel vuelo)
        {
            ViewModelReserva reserva = new ViewModelReserva();
            VuelosDAO vuelos = new VuelosDAO();
            return View(vuelos.GetVuelosByDate(vuelo.fechaSalida, vuelo.origen_iata, vuelo.destino_iata));
        }

        public IActionResult Reservar(string id_vuelo)
        {
            
            AvionesDAO aviones = new AvionesDAO();
            List<string> asientosDisponibles = aviones.GetAsientosDisponibles(id_vuelo);
            ViewBag.listaAsientosDisponibles = new SelectList(asientosDisponibles);
            TempData["id_vuelo"] = id_vuelo;
            return View(); 

        }

        public IActionResult EditarReserva(string id_vuelo, int user)
        {

            AvionesDAO aviones = new AvionesDAO();
            ReservasDAO reservas = new ReservasDAO();
            List<string> asientosDisponibles = aviones.GetAsientosDisponibles(id_vuelo);
            ViewBag.listaAsientosDisponibles = new SelectList(asientosDisponibles);
            TempData["id_vuelo"] = id_vuelo;
            ViewModelReserva infoReserva = reservas.GetPasajeroById(user);
            infoReserva.cant_maletas_extra = (int)TempData["cant_maletas_extra"];
            infoReserva.asiento = (string)TempData["asiento"];
            infoReserva.id_vuelo = id_vuelo;
            return View(infoReserva);

        }

        public IActionResult ConfirmacionReserva(ViewModelReserva infoReserva)
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            VuelosDAO vuelos = new VuelosDAO();
            infoReserva.id_vuelo = (string)TempData["id_vuelo"];
            TempData["asiento"] = infoReserva.asiento;
            TempData["cant_maletas_extra"] = infoReserva.cant_maletas_extra;
            VuelosModel infoVuelo = vuelos.GetVueloById(infoReserva.id_vuelo);
            ReservasDAO reservas = new ReservasDAO();
            infoReserva.fechaSalida = infoVuelo.fecha_hora;
            infoReserva.precio_maleta = infoVuelo.precio_equipaje_kilo;
            TempData["precio_maleta"] = infoReserva.precio_maleta;
            infoReserva.total_maletas = infoReserva.precio_maleta * infoReserva.cant_maletas_extra;
            TempData["total_maletas"] = infoReserva.total_maletas;
            infoReserva.origen_iata = infoVuelo.origen_iata;
            infoReserva.destino_iata = infoVuelo.destino_iata;
            AeropuertosModel infoAeropuertoOrigen = aeropuertos.GetAeropuertoById(infoReserva.origen_iata);
            AeropuertosModel infoAeropuertoDestino = aeropuertos.GetAeropuertoById(infoReserva.destino_iata);
            infoReserva.pais_origen = infoAeropuertoOrigen.nombre_pais;
            infoReserva.pais_destino = infoAeropuertoDestino.nombre_pais;
            infoReserva.nombre_aeropuerto_origen = infoAeropuertoOrigen.nombre_aeropuerto;
            infoReserva.nombre_aeropuerto_destino = infoAeropuertoDestino.nombre_aeropuerto;
            reservas.InsertPasajero(infoReserva);
            return View(infoReserva);

        }

        public IActionResult ReservaCompletada(string id_vuelo, int user)
        {
            AvionesDAO aviones = new AvionesDAO();
            ReservasDAO reservas = new ReservasDAO();
            VuelosDAO vuelos = new VuelosDAO();
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            ViewModelReserva infoReserva = reservas.GetPasajeroById(user);
            VuelosModel infoVuelo = vuelos.GetVueloById(id_vuelo);
            infoReserva.fechaSalida = infoVuelo.fecha_hora;
            infoReserva.precio_maleta = infoVuelo.precio_equipaje_kilo;
            infoReserva.cant_maletas_extra = (int)TempData["cant_maletas_extra"];
            infoReserva.asiento = (string)TempData["asiento"];
            infoReserva.id_vuelo = id_vuelo;
            infoReserva.origen_iata = infoVuelo.origen_iata;
            infoReserva.destino_iata = infoVuelo.destino_iata;
            AeropuertosModel infoAeropuertoOrigen = aeropuertos.GetAeropuertoById(infoReserva.origen_iata);
            AeropuertosModel infoAeropuertoDestino = aeropuertos.GetAeropuertoById(infoReserva.destino_iata);
            infoReserva.pais_origen = infoAeropuertoOrigen.nombre_pais;
            infoReserva.pais_destino = infoAeropuertoDestino.nombre_pais;
            infoReserva.nombre_aeropuerto_origen = infoAeropuertoOrigen.nombre_aeropuerto;
            infoReserva.nombre_aeropuerto_destino = infoAeropuertoDestino.nombre_aeropuerto;
            infoReserva.precio_maleta = (int)TempData["precio_maleta"];
            infoReserva.total_maletas = (int)TempData["total_maletas"];
            infoReserva.total = infoReserva.total_maletas + aviones.GetPrecioTiquete(id_vuelo, infoReserva.asiento, infoVuelo.precio_economica, infoVuelo.precio_primera);
            infoReserva.id = reservas.GenerarNumReserva();
            reservas.AddReserva(infoReserva);
            reservas.confirmationEmail(infoReserva);
            return View(infoReserva);
        }

        public IActionResult BuscarVueloRedondo()
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            List<AeropuertosModel> listaAeropuertos = aeropuertos.GetAllAeropuertos();
            ViewBag.listaAeropuertos = new SelectList(listaAeropuertos, "cod_iata", "fullDesc");
            return View();
        }

        public IActionResult VuelosRedondosEncontrados(VuelosModel vuelo, string origen_iata, string destino_iata)
        {
            TempData["ida"] = origen_iata;
            TempData["regreso"] = destino_iata;
            ViewModelReserva reserva = new ViewModelReserva();
            VuelosDAO vuelos = new VuelosDAO();
            List <VuelosModel> listaVuelos = new List<VuelosModel> ();
            List <VuelosModel> listaIda = vuelos.GetVuelosByDate(vuelo.fechaSalida, vuelo.origen_iata, vuelo.destino_iata);
            List<VuelosModel> listaVuelta = vuelos.GetVuelosByDate(vuelo.fechaRegreso,vuelo.destino_iata, vuelo.origen_iata);
            listaVuelos = listaIda.Concat(listaVuelta).ToList();
            return View(listaVuelos);
        }

        public IActionResult ReservarRedondo(string vuelo_ida, string vuelo_regreso)
        {
            TempData["vuelo_ida"] = vuelo_ida;
            TempData["vuelo_regreso"] = vuelo_regreso;
            AvionesDAO aviones = new AvionesDAO();
            List<string> asientosDisponiblesIda = aviones.GetAsientosDisponibles(vuelo_ida);
            ViewBag.listaAsientosDisponiblesIda = new SelectList(asientosDisponiblesIda);
            List<string> asientosDisponiblesRegreso = aviones.GetAsientosDisponibles(vuelo_regreso);
            ViewBag.listaAsientosDisponiblesRegreso = new SelectList(asientosDisponiblesRegreso);
            return View();

        }

        public IActionResult EditarReservaRedondo(string id_vuelo, int user, string vuelo_regreso)
        {

            AvionesDAO aviones = new AvionesDAO();
            ReservasDAO reservas = new ReservasDAO();
            List<string> asientosDisponiblesIda = aviones.GetAsientosDisponibles(id_vuelo);
            ViewBag.listaAsientosDisponiblesIda = new SelectList(asientosDisponiblesIda);
            List<string> asientosDisponiblesRegreso = aviones.GetAsientosDisponibles(vuelo_regreso);
            ViewBag.listaAsientosDisponiblesRegreso = new SelectList(asientosDisponiblesRegreso);
            TempData["vuelo_ida"] = id_vuelo;
            TempData["vuelo_regreso"] = vuelo_regreso;
            ViewModelReserva infoReserva = reservas.GetPasajeroById(user);
            infoReserva.cant_maletas_extra = (int)TempData["cant_maletas_extra"];
            infoReserva.asiento = (string)TempData["asiento"];
            infoReserva.asientoRegreso = (string)TempData["asientoRegreso"];
            infoReserva.id_vuelo = id_vuelo;
            infoReserva.id_vuelo_regreso = vuelo_regreso;
            return View(infoReserva);

        }

        public IActionResult ConfirmacionReservaRedondo(ViewModelReserva infoReserva, string asiento, string asientoRegreso)
        {
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            VuelosDAO vuelos = new VuelosDAO();
            infoReserva.id_vuelo = (string)TempData["vuelo_ida"];
            infoReserva.id_vuelo_regreso = (string)TempData["vuelo_regreso"];
            TempData["asiento"] = asiento;
            TempData["asientoRegreso"] = asientoRegreso;
            infoReserva.asiento = asiento;
            infoReserva.asientoRegreso = asientoRegreso;
            TempData["cant_maletas_extra"] = infoReserva.cant_maletas_extra;
            VuelosModel infoVueloIda = vuelos.GetVueloById((string)TempData["vuelo_ida"]);
            VuelosModel infoVueloRegreso = vuelos.GetVueloById(((string)TempData["vuelo_regreso"]));
            infoReserva.fechaRegreso = infoVueloRegreso.fecha_hora;
            ReservasDAO reservas = new ReservasDAO();
            infoReserva.fechaSalida = infoVueloIda.fecha_hora;
            infoReserva.precio_maleta = infoVueloIda.precio_equipaje_kilo;
            TempData["precio_maleta"] = infoReserva.precio_maleta;
            infoReserva.total_maletas = infoReserva.precio_maleta * infoReserva.cant_maletas_extra;
            TempData["total_maletas"] = infoReserva.total_maletas;
            infoReserva.origen_iata = infoVueloIda.origen_iata;
            infoReserva.destino_iata = infoVueloIda.destino_iata;
            AeropuertosModel infoAeropuertoOrigen = aeropuertos.GetAeropuertoById(infoReserva.origen_iata);
            AeropuertosModel infoAeropuertoDestino = aeropuertos.GetAeropuertoById(infoReserva.destino_iata);
            infoReserva.pais_origen = infoAeropuertoOrigen.nombre_pais;
            infoReserva.pais_destino = infoAeropuertoDestino.nombre_pais;
            infoReserva.nombre_aeropuerto_origen = infoAeropuertoOrigen.nombre_aeropuerto;
            infoReserva.nombre_aeropuerto_destino = infoAeropuertoDestino.nombre_aeropuerto;
            reservas.InsertPasajero(infoReserva);
            return View(infoReserva);

        }

        public IActionResult ReservaCompletadaRedondo(string id_vuelo, int user, string vuelo_regreso)
        {
            AvionesDAO aviones = new AvionesDAO();
            ReservasDAO reservas = new ReservasDAO();
            VuelosDAO vuelos = new VuelosDAO();
            AeropuertosDAO aeropuertos = new AeropuertosDAO();
            ViewModelReserva infoReserva = reservas.GetPasajeroById(user);
            VuelosModel infoVueloIda = vuelos.GetVueloById(id_vuelo);
            VuelosModel infoVueloRegreso = vuelos.GetVueloById(vuelo_regreso);
            infoReserva.fechaSalida = infoVueloIda.fecha_hora;
            infoReserva.fechaRegreso = infoVueloRegreso.fecha_hora;
            infoReserva.precio_maleta = infoVueloIda.precio_equipaje_kilo + infoVueloRegreso.precio_equipaje_kilo;
            infoReserva.cant_maletas_extra = (int)TempData["cant_maletas_extra"];
            infoReserva.asiento = (string)TempData["asiento"];
            infoReserva.asientoRegreso = (string)TempData["asientoRegreso"];
            infoReserva.id_vuelo = id_vuelo;
            infoReserva.id_vuelo_regreso = vuelo_regreso;
            infoReserva.origen_iata = infoVueloIda.origen_iata;
            infoReserva.destino_iata = infoVueloIda.destino_iata;
            AeropuertosModel infoAeropuertoOrigen = aeropuertos.GetAeropuertoById(infoReserva.origen_iata);
            AeropuertosModel infoAeropuertoDestino = aeropuertos.GetAeropuertoById(infoReserva.destino_iata);
            infoReserva.pais_origen = infoAeropuertoOrigen.nombre_pais;
            infoReserva.pais_destino = infoAeropuertoDestino.nombre_pais;
            infoReserva.nombre_aeropuerto_origen = infoAeropuertoOrigen.nombre_aeropuerto;
            infoReserva.nombre_aeropuerto_destino = infoAeropuertoDestino.nombre_aeropuerto;
            infoReserva.total_maletas = infoReserva.cant_maletas_extra * infoReserva.precio_maleta;
            infoReserva.total = infoReserva.total_maletas + (aviones.GetPrecioTiquete(id_vuelo, infoReserva.asiento, infoVueloIda.precio_economica, infoVueloIda.precio_primera)+ aviones.GetPrecioTiquete(id_vuelo, infoReserva.asientoRegreso, infoVueloRegreso.precio_economica, infoVueloRegreso.precio_primera));
            //Generar 2 reservas, una por cada vuelo
            string id_base = reservas.GenerarNumReserva();
            string id_ida = id_base + "-1";
            string id_regreso = id_base + "-2";
            infoReserva.id = id_ida;
            reservas.AddReserva(infoReserva);
            ViewModelReserva reservaRegreso = infoReserva;
            reservaRegreso.id = id_regreso;
            reservaRegreso.id_vuelo = reservaRegreso.id_vuelo_regreso;
            reservaRegreso.asiento = reservaRegreso.asientoRegreso;
            reservas.AddReserva(reservaRegreso);
            infoReserva.asiento = (string)TempData["asiento"];
            infoReserva.id_vuelo = id_vuelo;
            infoReserva.id = id_base;
            reservas.confirmationEmailRedondo(infoReserva);
            return View(infoReserva);
        }

    }
}
