using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AMcom.Teste.Dal.Interfaces;
using AMcom.Teste.DAL;
using GeoCoordinatePortable;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace AMcom.Teste.DAL
{
    public class UbsRepository : IUbsRepository
    {
        public List<Ubs> BuscarUbsProximas(GeoCoordinate geoCoordinate)
        {
            const int qtdItens = 5;

            return CarregarDados()
            .OrderBy(x => new GeoCoordinate((double)x.Latitude, (double)x.Longitude)
               .GetDistanceTo(geoCoordinate))
            .ThenByDescending(x => (int)x.AvalicaoNota)
            .Take(qtdItens)
            .ToList();
        }


        /// <summary>
        /// Responsável pela leitura do csv e carregamento dos dados ao list.
        /// </summary>
        /// <returns></returns>
        public List<CsvMappingResult<Ubs>> CarregarDados() {

            const string caminho = "C://usr";

            var reader = new StreamReader(caminho, Encoding.UTF8);

            var csvParserOptions = new CsvParserOptions(true, ',');
            var usbMap = new UbsMapping();
            var csvParser = new CsvParser<Ubs>(csvParserOptions, usbMap);

             return csvParser.ReadFromStream(reader.BaseStream, Encoding.UTF8).ToList();



            //return (ICollection<Ubs>)File.ReadAllLines(caminho).Select(a => a.Split(',').Select(c => new Ubs
            //{
            //    Vlr_Latitude = Convert.ToDouble(c[0]),
            //    Vlr_Longitude = Convert.ToDouble(c[1]),
            //    Nom_Estab = c[2].ToString(),
            //    Dsc_Endereco = c[3].ToString(),
            //    Dsc_Bairro = c[4].ToString(),
            //    Dsc_Cidade = c[5].ToString(),
            //   Dsc_Estrut_Fisic_Ambiencia = c[6].ToString(),
            //
            //})).ToList();
        }


        /// <summary>
        /// Mapeamento da entidade para o Csv
        /// </summary>
        private class UbsMapping : CsvMapping<Ubs>
        {
            public UbsMapping(): base()
            {
                MapProperty(0, x => x.Latitude);
                MapProperty(1, x => x.Longitude);
                MapProperty(2, x => x.Nome);
                MapProperty(3, x => x.Endereco);
                MapProperty(4, x => x.Bairro);
                MapProperty(5, x => x.Cidade);
                MapProperty(6, x => x.EstruturaFisica);

            }
        }
    }
}
