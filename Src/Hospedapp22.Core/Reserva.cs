using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospedapp22.Core
{
    public class Reserva
    {
        public int IdReserva{get;set;}
        public short IdHotel{get;set;}
        public DateTime Inicio{get;set;}
        public DateTime Fin{get;set;}
        public int IdCliente{get;set;}
        public short IdCuarto{get;set;}
        public double CostoNoche{get;set;}
        public byte CalificacionCliente{get;set;}
        public byte CalificacionHotel{get;set;}
        public string Descripcion{get;set;}
        public bool Cancelado{get;set;}
        public Reserva(){}
        public Reserva(int IdReserva,short IdHotel,DateTime Inicio,DateTime Fin,int IdCliente,short IdCuarto, double CostoNoche)
        {
            this.IdReserva = IdReserva;
            this.IdHotel=IdHotel;
            this.Inicio = Inicio; 
            this.Fin = Fin;
            this.IdCliente = IdCliente;
            this.IdCuarto = IdCuarto;
            this.CostoNoche = CostoNoche;
            
        }

    }
}