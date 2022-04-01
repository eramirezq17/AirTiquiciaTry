using AirTiquiciaTry.Models;

namespace AirTiquiciaTry.Services
{
    interface iAeropuertosDataService
    {
        List<AeropuertosModel> GetAllAeropuertos();

        List<AeropuertosModel> SearchAeropuertos(string searchTerm);

        AeropuertosModel GetAeropuertoById(int id);

        int Insert(AeropuertosModel aeropuerto);
        int Delete(AeropuertosModel aeropuerto);
        int Update(AeropuertosModel aeropuerto);
    }
}
