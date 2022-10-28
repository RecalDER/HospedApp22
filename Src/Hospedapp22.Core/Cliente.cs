using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospedapp22.Core
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Constrasenia { get; set; }
        public Cliente() { }
        public Cliente(int IdCliente, string Nombre, string Apellido, string Email, string Constrasenia)
        {
            this.IdCliente = IdCliente;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Email = Email;
            this.Constrasenia = Constrasenia;
        }

    }
}