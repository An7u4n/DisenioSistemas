using Model.Abstract;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class ReservaEsporadica : Reserva
    {

        public ReservaEsporadica(ReservaEsporadicaDTO esporadicaDTO): base(esporadicaDTO)
        {
            
        }

        public DiaEsporadica DiaEsporadica { get; set; }
    }
}
