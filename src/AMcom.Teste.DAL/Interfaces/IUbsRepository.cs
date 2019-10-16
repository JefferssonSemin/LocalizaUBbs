using System;
using System.Collections.Generic;
using AMcom.Teste.DAL;

namespace AMcom.Teste.Dal.Interfaces
{
    public interface IUbsRepository 
    {
        List<Ubs> BuscarUbs(double latitude, double longitude);
    }
}
