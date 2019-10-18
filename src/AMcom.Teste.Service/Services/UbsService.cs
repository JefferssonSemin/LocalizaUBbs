using AMcom.Teste.Dal.Interfaces;
using AMcom.Teste.Service.Dtos;
using AMcom.Teste.Service.Interfaces;
using GeoCoordinatePortable;
using System;
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
        public List<UbsDto> BucarUbsProximas(double longitude, double latitude)
        {
            if (!ValidaCoordenadas(longitude, latitude))
            {
                throw new Exception("Não é possivel buscar coordenadas com o valor 0");
            }

            if (latitude > 90 || latitude < -90 && longitude > 90 || longitude < -90)
                throw new Exception("A latitude e longitude deve estar entre 90 e -90");


            var coord = new GeoCoordinate(longitude, latitude);

            try
            {
                return _ubsRepository.CarregarDados().OrderBy(x =>
                    new GeoCoordinate(FormataCoordenada(x.Longitude), FormataCoordenada(x.Latitude))
                        .GetDistanceTo(coord)).Take(5).OrderByDescending(x => x.AvalicaoUbs).Select(a => (UbsDto)a).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível efetuar a consulta, erro: {ex.Message}");
            }
        }

        public bool ValidaCoordenadas(double longitude, double latitude) {

            return (!(Math.Abs(longitude) > 0) || !(Math.Abs(latitude) > 0));
        }

        /// <summary>
        /// Formata string em double removendo caracteres.
        /// </summary>
        /// <param name="coordenada"></param>
        /// <returns></returns>
        private static double FormataCoordenada(string coordenada) => double.Parse(coordenada?.Replace("-", "").Replace(".", ",") ?? throw new InvalidOperationException("Não há coordenadas disponíveis para serem formatadas."));
    }
}