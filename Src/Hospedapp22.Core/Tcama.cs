using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospedapp22.Core
{
    public class Tcama
    {
        public byte IdTipoCama{get;set;}
        public short IdCuarto{get;set;}
        public byte CantDeCamas{get;set;}
        public Tcama(){}
        public Tcama(byte IdTipoCama,short IdCuarto,byte CantDeCamas)
        {
            this.IdTipoCama = IdTipoCama;
            this.IdCuarto = IdCuarto;
            this.CantDeCamas = CantDeCamas;
        }
    }
}