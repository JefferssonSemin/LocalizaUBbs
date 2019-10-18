using AMcom.Teste.Dal.Interfaces;
using AMcom.Teste.DAL.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AMcom.Teste.DAL.Repository
{
    public class UbsRepository : IUbsRepository
    {
        private const string Caminho = @"C:\ubs.csv";

        /// <summary>
        /// Responsável pela leitura do csv e carregamento dos dados ao list.
        /// </summary>
        /// <returns></returns>
        public List<Ubs> CarregarDados()
        {
            using (var reader = new StreamReader(Caminho, Encoding.UTF8))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.PrepareHeaderForMatch = (header, index) => header.ToLower();
                csv.Configuration.Delimiter = ",";
                csv.Configuration.RegisterClassMap<UbsMapping>();
                return csv.GetRecords<Ubs>().ToList();
            }
        }

        /// <summary>
        /// Define o mapeamento do csv em relação ao seu header.
        /// </summary>
        private sealed class UbsMapping : ClassMap<Ubs>
        {
            public UbsMapping()
            {
                Map(x => x.Latitude).Name("vlr_latitude");
                Map(x => x.Longitude).Name("vlr_longitude");
                Map(x => x.Nome).Name("nom_estab");
                Map(x => x.Endereco).Name("dsc_endereco");
                Map(x => x.Bairro).Name("dsc_bairro");
                Map(x => x.Cidade).Name("dsc_cidade");
                Map(x => x.EstruturaFisica).Name("dsc_estrut_fisic_ambiencia");
            }
        }
    }
}