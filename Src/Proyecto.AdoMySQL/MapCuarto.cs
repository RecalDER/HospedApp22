using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Hospedapp22.Core;
using et12.edu.ar.AGBD.Ado;

namespace Hospedapp22.AdoMySQL.Mapeadores;
public class MapCuarto : Mapeador<Cuarto>
{
    public MapHotel MapHotel { get; set; }
    public MapCuarto(AdoAGBD ado) : base(ado) => Tabla = "Cuarto";
    public MapCuarto(MapHotel mapHotel) : this(mapHotel.AdoAGBD)
            => MapHotel = mapHotel;

    public override Cuarto ObjetoDesdeFila(DataRow fila)
        => new Cuarto()
        {
            NumCuarto = Convert.ToByte(fila["numCuarto"]),
            Hotel = MapHotel.HotelPorId(Convert.ToUInt16(fila["idHotel"])),
            Cochera = Convert.ToBoolean(fila["cochera"]),
            CostoNoche = Convert.ToDecimal(fila["costoNoche"]),
            Descripcion = fila["descripcion"].ToString()!,
            IdCuarto = Convert.ToByte(fila["idCuarto"])
        };
    public void AltaCuarto(Cuarto cuarto)
    => EjecutarComandoCon("AltaCuarto", ConfigurarAltaCuarto, PostAltaCuarto, cuarto);

    public Cuarto CuartoPorId(byte id)
        => FiltrarPorPK("idCuarto", id)!;
    public void ConfigurarAltaCuarto(Cuarto cuarto)
    {
        SetComandoSP("AltaCuarto");


        BP.CrearParametro("unidHotel")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(cuarto.Hotel.IdHotel)
            .AgregarParametro();

        BP.CrearParametro("unnumCuarto")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(cuarto.NumCuarto)
            .AgregarParametro();

        BP.CrearParametro("uncochera")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(cuarto.Cochera)
            .AgregarParametro();

        BP.CrearParametro("uncostoNoche")
            .SetTipoDecimal(7, 2)
            .SetValor(cuarto.CostoNoche)
            .AgregarParametro();

        BP.CrearParametro("undescripcion")
            .SetTipoVarchar(60)
            .SetValor(cuarto.Descripcion)
            .AgregarParametro();

        BP.CrearParametroSalida("unIdCuarto")
          .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
          .AgregarParametro();
    }
    public void PostAltaCuarto(Cuarto cuarto)
    {
        var paramnumCuarto = GetParametro("unnumCuarto");
        cuarto.NumCuarto = Convert.ToByte(paramnumCuarto.Value);
    }
    public List<Cuarto> ObtenerCuartos() => ColeccionDesdeTabla();
}