using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospedapp22.Core
{
    public class Cama
    {
        public byte IdTipoCama { get; set; }
        public string TipoCama { get; set; }
        public byte CantPersonas { get; set; }
        public Cama(){}
        public Cama(byte IdTipoCama, string TipoCama, byte CantPersonas)
        {
            this.IdTipoCama = IdTipoCama;
            this.TipoCama = TipoCama;
            this.CantPersonas = CantPersonas;
        }
    }
}