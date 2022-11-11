using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Hospedapp22.Core;
using et12.edu.ar.AGBD.Ado;

namespace Hospedapp22.AdoMySQL.Mapeadores;
public class MapCliente : Mapeador<Cliente>
{
    public MapCliente(AdoAGBD ado) : base(ado)
    {
        Tabla = "Cliente";
    }

    public override Cliente ObjetoDesdeFila(DataRow fila)
        => new Cliente()
        {
            IdCliente = Convert.ToInt16(fila["idCliente"]),
            Nombre = fila["nombre"].ToString(),
            Apellido = fila["apellido"].ToString(),
            Email = fila["email"].ToString(),
            Constrasenia = fila["contrasenia"].ToString()

        };
    public void RegistrarCliente(Cliente cliente)
    => EjecutarComandoCon("registrarCliente", ConfigurarAltaCliente, PostAltaCliente, cliente);

    public Cliente ClientePorId(int id)
        => FiltrarPorPK("idCliente", id)!;
    public void ConfigurarAltaCliente(Cliente cliente)
    {
        SetComandoSP("registrarCliente");

        BP.CrearParametro("unidCliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(cliente.IdCliente)
            .AgregarParametro();

        BP.CrearParametro("unnombre")
            .SetTipoVarchar(45)
            .SetValor(cliente.Nombre)
            .AgregarParametro();

        BP.CrearParametro("unapellido")
            .SetTipoVarchar(35)
            .SetValor(cliente.Apellido)
            .AgregarParametro();

        BP.CrearParametro("unemail")
            .SetTipoVarchar(25)
            .SetValor(cliente.Email)
            .AgregarParametro();

        BP.CrearParametro("uncontrasenia")
            .SetTipoVarchar(64)
            .SetValor(cliente.Constrasenia)
            .AgregarParametro();
    }
    public void PostAltaCliente(Cliente cliente)
    {
        var paramIdCliente = GetParametro("unIdCliente");
        cliente.IdCliente = Convert.ToByte(paramIdCliente.Value);
    }
    public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
}