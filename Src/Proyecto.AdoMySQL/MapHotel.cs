using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Hospedapp22.Core;
using et12.edu.ar.AGBD.Ado;

namespace Hospedapp22.AdoMySQL.Mapeadores;
public class MapHotel : Mapeador<Hotel>
{
    public MapHotel(AdoAGBD ado) : base(ado)
    {
        Tabla = "Hotel";
    }

    public override Hotel ObjetoDesdeFila(DataRow fila)
        => new Hotel()
        {
            IdHotel = Convert.ToUInt16(fila["idHotel"]),
            Nombre = fila["nombre"].ToString()!,
            Domicilio = fila["domicilio"].ToString()!,
            Email = fila["email"].ToString()!,
            Constrasenia = fila["contrasenia"].ToString()!,
            Estrellas = Convert.ToByte(fila["estrellas"])

        };
    public void altaHotel(Hotel hotel)
    => EjecutarComandoCon("AltaHotel", ConfigurarAltaHotel, PostAltaHotel, hotel);

    public Hotel HotelPorId(ushort id)
        => FiltrarPorPK("idHotel", id)!;
    public void ConfigurarAltaHotel(Hotel hotel)
    {
        SetComandoSP("AltaHotel");

        BP.CrearParametro("unidHotel")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(hotel.IdHotel)
            .AgregarParametro();

        BP.CrearParametro("unnombre")
            .SetTipoVarchar(45)
            .SetValor(hotel.Nombre)
            .AgregarParametro();

        BP.CrearParametro("undomicilio")
            .SetTipoVarchar(35)
            .SetValor(hotel.Domicilio)
            .AgregarParametro();

        BP.CrearParametro("unemail")
            .SetTipoVarchar(25)
            .SetValor(hotel.Email)
            .AgregarParametro();

        BP.CrearParametro("uncontrasenia")
            .SetTipoVarchar(64)
            .SetValor(hotel.Constrasenia)
            .AgregarParametro();

        BP.CrearParametro("unestrellas")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(hotel.Estrellas)
            .AgregarParametro();
    }
    public void PostAltaHotel(Hotel hotel)
    {
        var paramIdHotel = GetParametro("unIdHotel");
        hotel.IdHotel = Convert.ToByte(paramIdHotel.Value);
    }
    public List<Hotel> ObtenerHoteles() => ColeccionDesdeTabla();
}
