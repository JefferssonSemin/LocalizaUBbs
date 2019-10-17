using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AMcom.Teste.DAL.Entities
{
    /// <summary>
    /// Entidade de Ubs com seu mapeamento/name legado.
    /// </summary>
    public class Ubs
    {
        [Name("vlr_latitude")]
        public string Latitude { get; set; }

        [Name("vlr_longitude")]
        public string Longitude { get; set; }

        [Name("nom_estab")]
        public string Nome { get; set; }

        [Name("dsc_endereco")]
        public string Endereco { get; set; }

        [Name("dsc_bairro")]
        public string Bairro { get; set; }

        [Name("dsc_cidade")]
        public string Cidade { get; set; }

        [Name("dsc_estrut_fisic_ambiencia")]
        public string EstruturaFisica { get; set; }

        public UbsAvaliacao AvalicaoUbs => UbsExtension.MontaEnum(EstruturaFisica);
    }

    /// <summary>
    /// Monta o enum conforme monta o objeto adicionado à coleção.
    /// </summary>
    public static class UbsExtension
    {
        public static UbsAvaliacao MontaEnum(string avaliacao)
        {
            return new Dictionary<string, UbsAvaliacao>
            {
                {"Desempenho mediano ou  um pouco abaixo da média", UbsAvaliacao.Ruim},
                {"Desempenho acima da média", UbsAvaliacao.Bom},
                {"Desempenho muito acima da média", UbsAvaliacao.Excelente}
            }.First(x => x.Key == avaliacao).Value;
        }
    }

    /// <summary>
    /// Enumerador da avaliação da estrutura.
    /// </summary>
    public enum UbsAvaliacao
    {
        [Description("Ruim")]
        Ruim = 1,

        [Description("Bom")]
        Bom = 2,

        [Description("Excelente")]
        Excelente = 3
    }
}