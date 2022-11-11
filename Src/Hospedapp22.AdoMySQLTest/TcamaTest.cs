using Hospedapp22.Core;
using Hospedapp22.AdoMySQL;
using et12.edu.ar.AGBD.Ado;
namespace Hospedapp22.AdoMySQLTest;
public class TcamaTest
{
    public AdoHospedApp22 Ado { get; set; }
    public TcamaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoHospedApp22(adoAGBD);
    }

    [Fact]
    public void AltaTcama()
    {
        var tcama = new Tcama(Ado.ObtenerCamaPorId(2)!,Ado.ObtenerCuartoPorId(2)!,2);
        Ado.AltaTcama(tcama);
        Assert.Equal(2, tcama.Cuarto.IdCuarto);
    }

    [Theory]
    [InlineData(1,1)]
    public void TraerTcamas(byte idCama, byte idcuarto)
    {
        var Tcamas = Ado.ObtenerTcamas();
        Assert.Contains(Tcamas, T => T.Cama.IdCama == idCama && T.Cuarto.IdCuarto == idcuarto);
    }
}
