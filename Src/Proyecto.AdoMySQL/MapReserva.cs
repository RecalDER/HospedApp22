using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Hospedapp22.Core;
using et12.edu.ar.AGBD.Ado;

namespace Hospedapp22.AdoMySQL.Mapeadores;
public class MapReserva : Mapeador<Reserva>
{
    public MapHotel MapHotel { get; set; }
    public MapCuarto MapCuarto { get; set; }
    public MapCliente MapCliente { get; set;}
    public MapReserva(MapHotel mapHotel,MapCuarto mapCuarto, MapCliente mapCliente) : base(mapHotel.AdoAGBD)
    {
        MapHotel = mapHotel;
        MapCuarto = mapCuarto;
        MapCliente = mapCliente;
        Tabla = "Reserva";
    }

    public override Reserva ObjetoDesdeFila(DataRow fila)
        => new Reserva()
        {
            IdReserva = Convert.ToInt16(fila["idReserva"]),
            Hotel = MapHotel.HotelPorId(Convert.ToUInt16(fila["idHotel"])),
            Inicio = Convert.ToDateTime(fila["inicio"]),
            Fin = Convert.ToDateTime(fila["fin"]),
            Cuarto = MapCuarto.CuartoPorId(Convert.ToByte(fila["numCuarto"])),
            Cliente = MapCliente.ClientePorId(Convert.ToInt16(fila["idCliente"])),
            CostoNoche = Convert.ToDecimal(fila["costoNoche"])

        };
    public void AltaReserva(Reserva reserva)
    => EjecutarComandoCon("AltaReserva", ConfigurarAltaReserva, PostAltaReserva, reserva);

    public Reserva ReservaPorId(int id)
        => FiltrarPorPK("idReserva", id)!;
    public void ConfigurarAltaReserva(Reserva reserva)
    {
        SetComandoSP("AltaReserva");

        BP.CrearParametro("unidReserva")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(reserva.IdReserva)
            .AgregarParametro();

        BP.CrearParametro("unidHotel")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(reserva.Cliente.IdCliente)
            .AgregarParametro();

        BP.CrearParametro("uninicio")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(reserva.Inicio)
            .AgregarParametro();

        BP.CrearParametro("unfin")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(reserva.Fin)
            .AgregarParametro();

        BP.CrearParametro("unidCliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(reserva.Cliente.IdCliente)
            .AgregarParametro();

        BP.CrearParametro("unidCuarto")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(reserva.Cuarto.IdCuarto)
            .AgregarParametro();

        BP.CrearParametro("uncostoNoche")
            .SetTipoDecimal(7, 2)
            .SetValor(reserva.CostoNoche)
            .AgregarParametro();
    }
    public void PostAltaReserva(Reserva reserva)
    {
        var paramIdReserva = GetParametro("unidReserva");
        reserva.IdReserva = Convert.ToInt16(paramIdReserva.Value);
    }
    public List<Reserva> ObtenerReservas() => ColeccionDesdeTabla();
}