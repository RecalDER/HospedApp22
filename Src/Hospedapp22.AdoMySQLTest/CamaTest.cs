using Hospedapp22.Core;
using Hospedapp22.AdoMySQL;
using et12.edu.ar.AGBD.Ado;
namespace Hospedapp22.AdoMySQLTest;

public class CamaTest
{
    public AdoHospedApp22 Ado { get; set; }
    public CamaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoHospedApp22(adoAGBD);
    }

    [Fact]
    public void AltaCama()
    {
        var cama = new Cama(2,"lolera",2);
        Ado.AltaCama(cama);
        Assert.Equal(2, cama.IdCama);

    }

    [Theory]
    [InlineData(1, 2)]
    public void TraerCamas(byte id, byte CantP)
    {
        var camas = Ado.ObtenerCamas();
        Assert.Contains(camas, C => C.IdCama == id && C.CantPersonas == CantP);
    }
}