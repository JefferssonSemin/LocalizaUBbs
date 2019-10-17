using AMcom.Teste.DAL.Entities;
using System.Collections.Generic;

namespace AMcom.Teste.Dal.Interfaces
{
    public interface IUbsRepository
    {
        List<Ubs> CarregarDados();
    }
}