using et12.edu.ar.AGBD.Ado;
using Hospedapp22.AdoMySQL.Mapeadores;
using Hospedapp22.Core;
using Hospedapp22.Core.Ado;

namespace Hospedapp22.AdoMySQL;
public class AdoHospedApp22 : IAdo
{
    public AdoAGBD Ado { get; set; }
    public MapHotel MapHotel { get; set; }
    public MapCliente MapCliente { get; set; }
    public MapCuarto MapCuarto { get; set; }
    public AdoHospedApp22(AdoAGBD ado)
    {
        Ado = ado;
        MapHotel = new MapHotel(Ado);
        MapCliente = new MapCliente(Ado);
        MapCuarto = new MapCuarto(Ado);
    }
    public void AltaHotel(Hotel hotel) => MapHotel.altaHotel(hotel);
    public List<Hotel> ObtenerHoteles() => MapHotel.ColeccionDesdeTabla();
    public Hotel? ObtenerHotelPorId(ushort idHotel)
        => MapHotel.FiltrarPorPK("idHotel", idHotel);

    public void RegistrarCliente(Cliente cliente) => MapCliente.RegistrarCliente(cliente);
    public List<Cliente> ObtenerClientes() => MapCliente.ColeccionDesdeTabla();

    public void AltaCuarto(Cuarto cuarto) => MapCuarto.AltaCuarto(cuarto);
    public List<Cuarto> ObtenerCuartos() => MapCuarto.ColeccionDesdeTabla();
}