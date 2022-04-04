using AirTiquiciaTry.Models;

namespace AirTiquiciaTry.Services
{
    interface iAeropuertosDataService
    {
        List<AeropuertosModel> GetAllAeropuertos();

        List<AeropuertosModel> SearchAeropuertos(string searchTerm);

        AeropuertosModel GetAeropuertoById(string id);

        String Insert(AeropuertosModel aeropuerto);
        String Delete(AeropuertosModel aeropuerto);
        String Update(AeropuertosModel aeropuerto);
    }
}
