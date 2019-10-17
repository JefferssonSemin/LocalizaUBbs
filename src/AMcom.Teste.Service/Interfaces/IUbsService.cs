using System;
using System.Collections.Generic;
using AMcom.Teste.DAL;
using AMcom.Teste.Service.Dtos;

namespace AMcom.Teste.Service.Interfaces
{
    public interface IUbsService
    {
        List<Ubs> BucarUbsProximas(double latitude, double longitude);
    }
}
