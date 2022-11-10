using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Hospedapp22.Core;
using et12.edu.ar.AGBD.Ado;

namespace Hospedapp22.AdoMySQL.Mapeadores;
public class MapTcama : Mapeador<Tcama>
{
    public MapCuarto MapCuarto { get; set; }
    public MapTcama(AdoAGBD ado) : base(ado) => Tabla = "Tcama";
    public MapTcama(MapCuarto mapCuarto) : this(mapCuarto.AdoAGBD)
            => MapCuarto = mapCuarto;

    public override Tcama ObjetoDesdeFila(DataRow fila)
        => new Tcama()
        {
            IdTipoCama = Convert.ToByte(fila["idTipoCama"]),
            Cuarto = MapCuarto.CuartoPorId(Convert.ToByte(fila["idcuarto"])),
            CantDeCamas = Convert.ToByte(fila["cantDeCamas"])
        };
    public void AltaCuarto(Tcama tcama)
    => EjecutarComandoCon("AltaTcama", ConfigurarAltaTcama, PostAltaTcama, tcama);

    public Tcama TcamaPorId(byte id)
        => FiltrarPorPK("AltaTcama", id)!;
    public void ConfigurarAltaTcama(Tcama tcama)
    {
        SetComandoSP("AltaTcama");

        BP.CrearParametro("unidTipoCama")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(tcama.IdTipoCama)
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
        var paramnIdTipoCama = GetParametro("unidTipoCama");
        tcama.IdTipoCama = Convert.ToByte(paramnIdTipoCama.Value);
    }
    public List<Tcama> ObtenerTcamas() => ColeccionDesdeTabla();
}