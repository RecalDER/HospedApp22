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
            IdHotel = Convert.ToByte(fila["idHotel"]),
            Nombre = fila["nombre"].ToString(),
            Domicilio = fila["domicilio"].ToString(),
            Email = fila["email"].ToString(),
            Constrasenia = fila["contrasenia"].ToString(),
            Estrellas = Convert.ToByte(fila["estrellas"])

        };
    public void AltaRubro(Hotel hotel)
    => EjecutarComandoCon("altaHotel", ConfigurarAltaHotel, PostAltaHotel, hotel);

    public Hotel HotelPorId(byte id)
    {
        SetComandoSP("HotelPorId");//dudaaa

        BP.CrearParametro("unIdHotel")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(id)
            .AgregarParametro();

        return ElementoDesdeSP();
    }
    public void ConfigurarAltaHotel(Hotel hotel)
    {
        SetComandoSP("altaHotel");

        BP.CrearParametroSalida("unIdHotel")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .AgregarParametro();

        BP.CrearParametro("unHotel")
            .SetTipoVarchar(45)
            .SetValor(hotel.Nombre)
            .AgregarParametro();
    }
    public void PostAltaHotel(Hotel hotel)
    {
        var paramIdHotel = GetParametro("unIdHotel");
        hotel.IdHotel = Convert.ToByte(paramIdHotel.Value);
    }
    public List<Hotel> ObtenerHotel() => ColeccionDesdeTabla();
}