using AMcom.Teste.Service.Services;
using Xunit;
using AMcom.Teste.Service.Interfaces;
using NSubstitute;
using AMcom.Teste.Service.Dtos;
using System.Collections.Generic;
using AMcom.Teste.DAL.Entities;

namespace AMcom.Teste.Service.Tests
{
    /// <summary>
    /// O projeto foi desenvolvido no windows for mac e infelizmente não foi possível 
    /// executar os testes por conta de problemas na IDE, porém deixo a implementação e a ideia.
    /// </summary>
    public class UbsServiceTest
    {

        private const double LO = 10.000;
        private const double LAT = 20.000;

        private IUbsService mock;

        [Fact]
        public void UbsService_RetornoUbs_DeveSerTrue()
        {
            mock = Substitute.For<IUbsService>();

            UbsDto ubs = new UbsDto("joão da Silva, 252, sao paulo", "Empresa XYZ", UbsAvaliacao.Bom);
            
            List<UbsDto> ubsLista = new List<UbsDto>();
            ubsLista.Add(ubs);

            mock.BucarUbsProximas(LAT, LO).Returns(ubsLista);
        }

        [Theory]
        [InlineData(0, 75.1546)]
        [InlineData(10.5487, 0)]
        public void UbsService_LatitudeLongitude0_GeraTrue(double latitude, double longitude)
        {
            var mockService = Substitute.For<UbsService>();
            var resultadoEsperado = mockService.ValidaCoordenadas(latitude, longitude);

            var resultado = latitude.Equals(0) || latitude.Equals(0);

            Assert.Equal(resultado, resultadoEsperado);
        }

        //[Theory]
        //[InlineData(0, 75.1546)]
        //[InlineData(10.5487, 0)]
        //public void UbsService_ValidaLongitudeLatitude_DeveGerarFalha(double latitude, double longitude)
        //{
        //    var resultado = latitude.Equals(0) || longitude.Equals(0);

        //    Assert.True(resultado);
        //}

    }
}
