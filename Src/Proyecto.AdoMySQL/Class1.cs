using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Hospedapp22.Core;
using et12.edu.ar.AGBD.Ado;

namespace Hospedapp22.AdoMySQL.Mapeadores;
public class MapHotel : Mapeador<Hotel>
{
    public MapHotel(AdoAGBD ado) : base(ado)
    {
        Tabla ="Hotel";
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
}
