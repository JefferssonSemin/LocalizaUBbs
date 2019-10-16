using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AMcom.Teste.Dal.Interfaces;
using AMcom.Teste.DAL;

namespace AMcom.Teste.DAL
{
    public class UbsRepository : IUbsRepository
    {
        public List<Ubs> BuscarUbsProximas(double latitude, double longitude)
        {

            return null;
        }

        public ICollection<Ubs> CarregaDados() {

            const string caminho = "C://usr";

            return (ICollection<Ubs>)File.ReadAllLines(caminho).Select(a => a.Split(',').Select(c => new Ubs
            {
                Vlr_Latitude = Convert.ToDouble(c[0]),
                Vlr_Longitude = Convert.ToDouble(c[1]),
                Nom_Estab = c[2].ToString(),
                Dsc_Endereco = c[3].ToString(),
                Dsc_Bairro = c[4].ToString(),
                Dsc_Cidade = c[5].ToString(),
                Dsc_Estrut_Fisic_Ambiencia = c[6].ToString(),

            })).ToList();
        }
    }
}
