using AMcom.Teste.Dal.Interfaces;
using AMcom.Teste.Service.Dtos;
using AMcom.Teste.Service.Interfaces;
using GeoCoordinatePortable;
using System.Collections.Generic;
using System.Linq;

namespace AMcom.Teste.Service.Services
{
    public class UbsService : IUbsService
    {
        private readonly IUbsRepository _ubsRepository;

        public UbsService(IUbsRepository ubsRepository)
        {
            _ubsRepository = ubsRepository;
        }

        /// <summary>
        /// Lógica que busca do modelo carregado as ubs mais próxima a coordenada informada.
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public List<UbsDTO> BucarUbsProximas(double longitude, double latitude)
        {
            var coord = new GeoCoordinate(longitude, latitude);

            return _ubsRepository.CarregarDados().OrderBy(x =>
                 new GeoCoordinate(FormataCoordenada(x.Longitude), FormataCoordenada(x.Latitude))
                     .GetDistanceTo(coord)).Take(5).Select(a => (UbsDTO)a).ToList();
        }

        /// <summary>
        /// Formata string em double removendo caracteres.
        /// </summary>
        /// <param name="coordenada"></param>
        /// <returns></returns>
        private static double FormataCoordenada(string coordenada) => double.Parse(coordenada.Replace("-", "").Replace(".", ","));
    }
}