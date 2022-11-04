using Hospedapp22.Core;
using Hospedapp22.AdoMySQL;
using et12.edu.ar.AGBD.Ado;
namespace Hospedapp22.AdoMySQLTest;
public class ClienteTest
{
    public AdoHospedApp22 Ado { get; set; }
    public ClienteTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoHospedApp22(adoAGBD);
    }

    [Fact]
    public void AltaCliente()
    {
        var cliente = new Cliente(2, "Ulise", "Guerrero", "Ulise9@gmail.com", "Elmascapito100");
        Ado.RegistrarCliente(cliente);
        Assert.Equal(2, cliente.IdCliente);
    }

    [Theory]
    [InlineData(1, "Roberto")]
    public void TraerClientees(byte id, string nombre)
    {
        var cliente = Ado.ObtenerClientes();
        Assert.Contains(cliente, c => c.IdCliente == id && c.Nombre == nombre);
    }
}
