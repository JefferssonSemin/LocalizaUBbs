
namespace AMcom.Teste.Service.Tests
{
  public class UbsServiceTest
  {
    [Theory(DisplayName = "Latitude e longitudae igual a deve gerar erro")]
    [InlineData(0)]
    public void UbsService_LongitudeLatitude0_DeveGerarErro(double latitude)
    {

      Assert.(0, "a latitude está inválida");
    }

  }
}
