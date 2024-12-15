using Model.Abstract;
using Model.DTO;
using Model.Enums;

namespace Model.Entity
{
    public class ReservaEsporadica : Reserva
    {

        public ReservaEsporadica(ReservaEsporadicaDTO esporadicaDTO , List<DiaEsporadica> dias): base(esporadicaDTO)
        {
            this.DiaEsporadica = dias;
        }

        public ReservaEsporadica() { }

        public List<DiaEsporadica> DiaEsporadica { get; set; }
    }
}
