using System;
using System.Collections.Generic;
using AMcom.Teste.Service.Dtos;

namespace AMcom.Teste.Service.Interfaces
{
    public interface IUbsService
    {
        List<UbsDTO> UbsProximas(double longitude, double latidude);
    }
}
