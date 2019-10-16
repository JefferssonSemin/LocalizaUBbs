using System;
using System.Collections.Generic;
using AMcom.Teste.Service.Dtos;

namespace AMcom.Teste.Service.Interfaces
{
    public interface IUbsService
    {
        List<UbsDTO> BucarUbsProximas(double latitude, double longitude);
    }
}
