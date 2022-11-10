using Hospedapp22.Core;
using Hospedapp22.AdoMySQL;
using et12.edu.ar.AGBD.Ado;
namespace Hospedapp22.AdoMySQLTest;
public class CuartoTest
{
    public AdoHospedApp22 Ado { get; set; }
    public CuartoTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoHospedApp22(adoAGBD);
    }

    [Fact]
    public void AltaCuarto()
    {
        var cuarto = new Cuarto(Ado.ObtenerHotelPorId(1)!, 2, false, 100, "nose");
        Ado.AltaCuarto(cuarto);
        Assert.Equal(2, cuarto.NumCuarto);
    }

    [Theory]
    [InlineData(1)]
    public void TraerCuartos(byte IdCuarto)
    {
        var cuarto = Ado.ObtenerCuartos();
        Assert.Contains(cuarto, c => c.IdCuarto == IdCuarto);
    }
}
