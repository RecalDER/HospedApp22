namespace Hospedapp22.AdoMySQLTest;

public class HotelTest
{
    public AdoHotel Ado { get; set; }
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
        Assert.Equal(1, hotel.idHotel);
    }

    [Theory]
    [InlineData(1, "HotelLol")]
    public void TraerHoteles(byte id, string nombre)
    {
        var hotel = Ado.ObtenerHotel();
        Assert.Contains(hotel, r => r.Id == id && r.Nombre == nombre);
    }
}