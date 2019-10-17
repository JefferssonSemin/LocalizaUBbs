using AMcom.Teste.DAL.Entities;

namespace AMcom.Teste.Service.Dtos
{
    public class UbsDTO
    {
        private UbsDTO(string nome, string endereco, UbsAvaliacao avalicaoUbs)
        {
            Nome = nome;
            Endereco = endereco;
            Avaliacao = avalicaoUbs.GetType().FullName;
        }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Avaliacao { get; set; }

        public static explicit operator UbsDTO(Ubs v)
        {
            return new UbsDTO(v.Nome, v.Endereco, v.AvalicaoUbs);
        }
    }
}