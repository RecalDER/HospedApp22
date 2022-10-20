using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospedapp22.Core
{
    public class Hotel
    {
        public short IdHotel { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public string Constrasenia { get; set; }
        public byte Estrellas { get; set; }

        public Hotel() { }
        public Hotel(short IdHotel, string Nombre, string Domicilio, string Email, string Constrasenia, byte Estrellas)
        {
            this.IdHotel = IdHotel;
            this.Nombre = Nombre;
            this.Domicilio = Domicilio;
            this.Email = Email;
            this.Constrasenia = Constrasenia;
            this.Estrellas = Estrellas;
        }
    }

}
