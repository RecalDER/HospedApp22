using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospedapp22.Core
{
    public class Cama
    {
        public byte IdCama { get; set; }
        public string TipoCama { get; set; }
        public byte CantPersonas { get; set; }
        public Cama(){}
        public Cama(byte IdCama, string TipoCama, byte CantPersonas)
        {
            this.IdCama = IdCama;
            this.TipoCama = TipoCama;
            this.CantPersonas = CantPersonas;
        }
    }
}