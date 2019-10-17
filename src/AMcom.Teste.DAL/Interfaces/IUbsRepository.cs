using System;
using System.Collections.Generic;
using AMcom.Teste.DAL;
using GeoCoordinatePortable;
using TinyCsvParser.Mapping;

namespace AMcom.Teste.Dal.Interfaces
{
    public interface IUbsRepository 
    {
        List<Ubs> BuscarUbsProximas(GeoCoordinate geoCoordinate);

        List<CsvMappingResult<Ubs>> CarregarDados();
    }
}
