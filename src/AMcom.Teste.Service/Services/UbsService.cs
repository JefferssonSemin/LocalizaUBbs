using System;
using System.Collections.Generic;
using System.Linq;
using AMcom.Teste.Dal.Interfaces;
using AMcom.Teste.Service.Dtos;
using AMcom.Teste.Service.Interfaces;

namespace AMcom.Teste.Service.Services
{
    public class UbsService : IUbsService
    {
        private readonly IUbsRepository _ubsRepository;

        public UbsService(IUbsRepository ubsRepository)
        {
            _ubsRepository = ubsRepository;
        }

        // Implemente um método que retorne as 5 UBSs mais próximas de um ponto (latitude e longitude) que devem 
        // ser passados como parâmetro para o método e retorne uma lista/coleção de objetos do tipo UbsDTO.
        // Esta lista deve estar ordenada pela avaliação (da melhor para a pior) de acordo com os dados que constam
        // no objeto retornado pela camada de acesso a dados (DAL).
        public List<UbsDTO> BucarUbsProximas(double longitude, double latitude)
        {
            try
            {
               )_ubsRepository.BuscarUbsProximas().Select(x => new UbsDTO
                {
                    Avaliacao = x.Nom_Estab,
                    Endereco = x.Dsc_Endereco,
                    Nome = x.Nom_Estab
                });
                 
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
