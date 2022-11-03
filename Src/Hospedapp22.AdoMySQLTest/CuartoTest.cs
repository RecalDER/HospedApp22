using Hospedapp22.Core;
using Hospedapp22.AdoMySQL;
using et12.edu.ar.AGBD.Ado;
namespace Hospedapp22.AdoMySQLTest;
public class CuartoTest
{
    public AdoTest Ado { get; set; }
    public CuartoTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }

    [Fact]
    public void AltaCuarto()
    {
        var Hotel = Ado.ObtenerHoteles();
        var cuarto = new Cuarto(Hotel[1], 2, false, 100, "nose");
        Ado.AltaCuarto(cuarto);
        Assert.Equal(2, 2);
    }

    [Theory]
    [InlineData(1, "Roberto")]
    public void TraerCuartoes(byte id, string nombre)
    {
        var cuarto = Ado.ObtenerCuartos();
        Assert.Contains(cuarto, c => c.NumCuarto == id);
    }
}
