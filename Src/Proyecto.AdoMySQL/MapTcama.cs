using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Hospedapp22.Core;
using et12.edu.ar.AGBD.Ado;

namespace Hospedapp22.AdoMySQL.Mapeadores;
public class MapTcama : Mapeador<Tcama>
{
    public MapCuarto MapCuarto { get; set; }
    public MapCama MapCama { get; set; }
    public MapTcama(MapCuarto mapCuarto, MapCama mapCama) : base(mapCuarto.AdoAGBD) 
    {
        MapCuarto = mapCuarto;
        MapCama = mapCama;
        Tabla = "Tcama";
    }

    public override Tcama ObjetoDesdeFila(DataRow fila)
        => new Tcama()
        {
            Cama = MapCama.CamaPorId(Convert.ToByte(fila["idCama"])),
            Cuarto = MapCuarto.CuartoPorId(Convert.ToByte(fila["idcuarto"])),
            CantDeCamas = Convert.ToByte(fila["cantDeCamas"])
        };
    public void AltaTcama(Tcama tcama)
    => EjecutarComandoCon("AltaTcama", ConfigurarAltaTcama, tcama);

    public Tcama TcamaPorId(byte id)
        => FiltrarPorPK("idCuarto", id)!;
    public void ConfigurarAltaTcama(Tcama tcama)
    {
        SetComandoSP("AltaTcama");

        BP.CrearParametro("unidCama")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(tcama.Cama.IdCama)
            .AgregarParametro();

        BP.CrearParametro("unidCuarto")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(tcama.Cuarto.IdCuarto)
            .AgregarParametro();

        BP.CrearParametro("uncantDeCamas")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(tcama.CantDeCamas)
            .AgregarParametro();
    }
    public void PostAltaTcama(Tcama tcama)
    {
        var paramnIdCama = GetParametro("unidCama");
        tcama.Cama.IdCama = Convert.ToByte(paramnIdCama.Value);
    }
    public List<Tcama> ObtenerTcamas() => ColeccionDesdeTabla();
}