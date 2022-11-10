using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospedapp22.Core
{
    public class Tcama
    {
        public byte IdTipoCama { get; set; }
        public Cuarto Cuarto { get; set; }
        public byte CantDeCamas { get; set; }
        public Tcama() { }
        public Tcama(byte IdTipoCama, Cuarto Cuarto, byte CantDeCamas)
        {
            this.IdTipoCama = IdTipoCama;
            this.Cuarto = Cuarto;
            this.CantDeCamas = CantDeCamas;
        }
    }
}