using AMcom.Teste.DAL.Entities;

namespace AMcom.Teste.Service.Dtos
{
  /// <summary>
  /// Modelo de retorno, que carrega seu modelo no construtor definindo sua estutura no método explicit operator.
  /// </summary>
  public class UbsDto
  {
    private UbsDto(string nome, string endereco, UbsAvaliacao avalicaoUbs)
    {
      Nome = nome;
      Endereco = endereco;
      Avaliacao = avalicaoUbs.ToString();
    }

    public string Nome { get; set; }

    public string Endereco { get; set; }

    public string Avaliacao { get; set; }

    public static explicit operator UbsDto(Ubs v)
    {
      return new UbsDto(v.Nome, $"{v.Endereco} , {v.Bairro} , {v.Cidade}", v.AvalicaoUbs);
    }
  }
}