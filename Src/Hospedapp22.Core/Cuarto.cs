using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospedapp22.Core
{
    public class Cuarto
    {
        public byte NumCuarto { get; set; }
        public Hotel Hotel { get; set; }
        public bool Cochera { get; set; }
        public Decimal CostoNoche { get; set; }
        public string Descripcion { get; set; }
        public byte IdCuarto { get; set; }
        public Cuarto() { }
        public Cuarto(Hotel Hotel, byte NumCuarto, bool Cochera, Decimal CostoNoche, string Descripcion)
        {
            this.Hotel = Hotel; this.NumCuarto = NumCuarto;
            this.Cochera = Cochera; this.CostoNoche = CostoNoche;
            this.Descripcion = Descripcion;
        }
    }
}