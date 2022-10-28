using et12.edu.ar.AGBD.Ado;
using Hospedapp22.AdoMySQL.Mapeadores;
using Hospedapp22.Core;
using Hospedapp22.Core.Ado;

namespace Hospedapp22.AdoMySQL;
public class AdoHotel : IAdo
{
    public AdoAGBD Ado { get; set; }
    public MapHotel MapHotel { get; set; }
    public AdoHotel(AdoAGBD ado)
    {
        Ado = ado;
        MapHotel = new MapHotel(Ado);
    }
    public void AltaHotel(Hotel hotel) => MapHotel.altaHotel(hotel);

    public List<Hotel> ObtenerHotel() => MapHotel.ColeccionDesdeTabla();
}