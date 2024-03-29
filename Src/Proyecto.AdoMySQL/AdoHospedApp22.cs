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
    public MapCama MapCama{ get; set;}
    public MapTcama MapTcama{ get; set;}
    public MapReserva MapReserva{ get; set;}
    public AdoHospedApp22(AdoAGBD ado)
    {
        Ado = ado;
        MapHotel = new MapHotel(Ado);
        MapCliente = new MapCliente(Ado);
        MapCuarto = new MapCuarto(MapHotel);
        MapCama = new MapCama(Ado);
        MapTcama = new MapTcama(MapCuarto, MapCama);
        MapReserva = new MapReserva(MapHotel,MapCuarto,MapCliente);
    }
    public void AltaHotel(Hotel hotel) => MapHotel.altaHotel(hotel);
    public List<Hotel> ObtenerHoteles() => MapHotel.ColeccionDesdeTabla();
    public Hotel? ObtenerHotelPorId(ushort idHotel)
        => MapHotel.FiltrarPorPK("idHotel", idHotel);

    public void RegistrarCliente(Cliente cliente) => MapCliente.RegistrarCliente(cliente);
    public List<Cliente> ObtenerClientes() => MapCliente.ColeccionDesdeTabla();
    public Cliente? ObtenerClientePorId(int idCliente)
        => MapCliente.FiltrarPorPK("idCliente", idCliente);

    public void AltaCuarto(Cuarto cuarto) => MapCuarto.AltaCuarto(cuarto);
    public List<Cuarto> ObtenerCuartos() => MapCuarto.ColeccionDesdeTabla();
    public Cuarto? ObtenerCuartoPorId(byte NumCuarto)
        => MapCuarto.FiltrarPorPK("numCuarto", NumCuarto);

    public void AltaCama(Cama cama) => MapCama.AltaCama(cama);
    public List<Cama> ObtenerCamas() => MapCama.ColeccionDesdeTabla();
    public Cama? ObtenerCamaPorId(byte IdCama)
        => MapCama.FiltrarPorPK("idCama", IdCama);
    public void AltaTcama(Tcama tcama) => MapTcama.AltaTcama(tcama);
    public List<Tcama> ObtenerTcamas() => MapTcama.ColeccionDesdeTabla();

    public void AltaReserva(Reserva reserva) => MapReserva.AltaReserva(reserva);
    public List<Reserva> ObtenerReservas() => MapReserva.ColeccionDesdeTabla();

}