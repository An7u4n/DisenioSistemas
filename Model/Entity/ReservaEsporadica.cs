using Model.Abstract;
using Model.DTO;
using Model.Enums;

namespace Model.Entity
{
    public class ReservaEsporadica : Reserva
    {
        public virtual List<DiaEsporadica> DiasEsporadica { get; set; }
        
        public ReservaEsporadica(ReservaEsporadicaDTO esporadicaDTO , List<DiaEsporadica> dias): base(esporadicaDTO)
        {
            this.DiasEsporadica = dias;
        }

        public ReservaEsporadica() { }

    }
}
