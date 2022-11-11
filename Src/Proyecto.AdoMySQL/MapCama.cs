using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Hospedapp22.Core;
using et12.edu.ar.AGBD.Ado;

namespace Hospedapp22.AdoMySQL.Mapeadores;
public class MapCama : Mapeador<Cama>
{
    public MapCama(AdoAGBD ado) : base(ado)
    {
        Tabla = "Cama";
    }

    public override Cama ObjetoDesdeFila(DataRow fila)
        => new Cama()
        {
            IdCama = Convert.ToByte(fila["idCama"]),
            TipoCama = fila["tipoCama"].ToString()!,
            CantPersonas = Convert.ToByte(fila["cantPersonas"])

        };
    public void AltaCama(Cama cama)
    => EjecutarComandoCon("AltaCama", ConfigurarAltaCama, PostAltaCama, cama);

    public Cama CamaPorId(byte id)
        => FiltrarPorPK("idCama", id)!;
    public void ConfigurarAltaCama(Cama cama)
    {
        SetComandoSP("AltaCama");

        BP.CrearParametro("unidCama")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(cama.IdCama)
            .AgregarParametro();

        BP.CrearParametro("untipoCama")
            .SetTipoVarchar(15)
            .SetValor(cama.TipoCama)
            .AgregarParametro();

        BP.CrearParametro("uncantPersonas")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(cama.CantPersonas)
            .AgregarParametro();
    }
    public void PostAltaCama(Cama cama)
    {
        var paramIdCama = GetParametro("unidCama");
        cama.IdCama = Convert.ToByte(paramIdCama.Value);
    }
    public List<Cama> ObtenerCamas() => ColeccionDesdeTabla();
}

