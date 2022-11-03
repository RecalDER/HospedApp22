using Hospedapp22.Core;
using Hospedapp22.AdoMySQL;
using et12.edu.ar.AGBD.Ado;
namespace Hospedapp22.AdoMySQLTest;

public class HotelTest
{
    public AdoTest Ado { get; set; }
    public HotelTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoTest(adoAGBD);
    }

    [Fact]
    public void AltaHotel()
    {
        var hotel = new Hotel(2, "Agresivo", "nose", "Agresivo09@gmail.com", "elmati", 5);
        Ado.AltaHotel(hotel);
        Assert.Equal(2, hotel.IdHotel);

    }

    [Theory]
    [InlineData(1, "HotelLol")]
    public void TraerHoteles(byte id, string nombre)
    {
        var hotel = Ado.ObtenerHoteles();
        Assert.Contains(hotel, h => h.IdHotel == id && h.Nombre == nombre);
    }
}