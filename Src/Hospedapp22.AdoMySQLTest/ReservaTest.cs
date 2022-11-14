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
        DateTime inicio = new DateTime(2022,11,13);
        DateTime fin = new DateTime(2022,11,14);
        var reserva = new Reserva(2,Ado.ObtenerHotelPorId(1),inicio,fin,Ado.ObtenerClientePorId(1),Ado.ObtenerCuartoPorId(1),700);
        Ado.AltaReserva(reserva);
        Assert.Equal(2, reserva.IdReserva);
    }

    [Theory]
    [InlineData(1,1)]
    public void TraerReservas(byte Id, byte idHotel)
    {
        var Reservas = Ado.ObtenerReservas();
        Assert.Contains(Reservas, R => R.IdReserva == Id && R.Hotel.IdHotel == idHotel);
    }
}
