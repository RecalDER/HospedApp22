using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Hospedapp22.Core;
using et12.edu.ar.AGBD.Ado;

namespace Hospedapp22.AdoMySQL.Mapeadores;
public class MapCama : Mapeador<Cama>
{// FALTAA
    public MapCama(AdoAGBD ado) : base(ado)
    {
        Tabla = "Cama";
    }

    public override Cama ObjetoDesdeFila(DataRow fila)
        => new Cama()
        {
            IdTipoCama = Convert.ToByte(fila["unidTipoCama"]),
            TipoCama = fila["untipoCama"].ToString(),
            CantPersonas = Convert.ToByte(fila["uncantPersonas"])

        };
    public void altaCama(Cama hotel)
    => EjecutarComandoCon("AltaCama", ConfigurarAltaCama, PostAltaCama, hotel);

    public Cama CamaPorId(ushort id)
        => FiltrarPorPK("idCama", id)!;
    public void ConfigurarAltaCama(Cama hotel)
    {
        SetComandoSP("AltaCama");

        BP.CrearParametro("unidCama")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(hotel.IdCama)
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
    public void PostAltaCama(Cama hotel)
    {
        var paramIdCama = GetParametro("unIdCama");
        hotel.IdCama = Convert.ToByte(paramIdCama.Value);
    }
    public List<Cama> ObtenerCamaes() => ColeccionDesdeTabla();
}
