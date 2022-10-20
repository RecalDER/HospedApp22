using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospedapp22.Core
{
    public class Cuarto
    {
        public sbyte NumCuarto { get; set; }
        public short IdHotel { get; set; }
        public bool Cochera{get;set;}
        public double CostoNoche{get;set;}
        public string Descripcion{get;set;}
        public Cuarto(){}
        public Cuarto(short IdHotel, sbyte NumCuarto, bool Cochera, double CostoNoche, string Descripcion)
        {
            this.IdHotel = IdHotel; this.NumCuarto = NumCuarto;
            this.Cochera = Cochera; this.CostoNoche = CostoNoche;
            this.Descripcion = Descripcion;
        }
    }
}