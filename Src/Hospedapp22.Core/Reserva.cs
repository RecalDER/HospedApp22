using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospedapp22.Core
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public Cliente Cliente { get; set; }
        public Cuarto Cuarto { get; set; }
        public Decimal CostoNoche { get; set; }
        public byte CalificacionCliente { get; set; }
        public byte CalificacionHotel { get; set; }
        public string Descripcion { get; set; }
        public bool Cancelado { get; set; }
        public Reserva() { }
        public Reserva(int IdReserva, Hotel Hotel, DateTime Inicio, DateTime Fin, Cliente Cliente, Cuarto Cuarto, Decimal CostoNoche)
        {
            this.IdReserva = IdReserva;
            this.Hotel = Hotel;
            this.Inicio = Inicio;
            this.Fin = Fin;
            this.Cliente = Cliente;
            this.Cuarto = Cuarto;
            this.CostoNoche = CostoNoche;

        }

    }
}