using Hospedapp22.Core;
using Hospedapp22.AdoMySQL;
using et12.edu.ar.AGBD.Ado;
namespace Hospedapp22.AdoMySQLTest;
public class ReservaTest
{
    public AdoHospedApp22 Ado { get; set; }
    public ReservaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoHospedApp22(adoAGBD);
    }

    [Fact]
    public void AltaReserva()
    {
        var reserva = new Reserva();
        Ado.AltaReserva(reserva);
        Assert.Equal(2, reserva.IdReserva);
    }

    [Theory]
    [InlineData(1,1)]
    public void TraerTcamas(byte idCama, byte idcuarto)
    {
        var Tcamas = Ado.ObtenerTcamas();
        Assert.Contains(Tcamas, T => T.Cama.IdCama == idCama && T.Cuarto.IdCuarto == idcuarto);
    }
}
