using AMcom.Teste.Service.Dtos;
using System.Collections.Generic;

namespace AMcom.Teste.Service.Interfaces
{
    public interface IUbsService
    {
        List<UbsDto> BucarUbsProximas(double latitude, double longitude);
    }
}