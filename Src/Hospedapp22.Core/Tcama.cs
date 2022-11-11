using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospedapp22.Core
{
    public class Tcama
    {
        public Cama Cama { get; set; }
        public Cuarto Cuarto { get; set; }
        public byte CantDeCamas { get; set; }
        public Tcama() { }
        public Tcama(Cama Cama, Cuarto Cuarto, byte CantDeCamas)
        {
            this.Cama = Cama;
            this.Cuarto = Cuarto;
            this.CantDeCamas = CantDeCamas;
        }
    }
}