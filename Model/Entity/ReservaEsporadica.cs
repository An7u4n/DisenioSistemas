using Model.Abstract;
using Model.DTO;
using Model.Enums;

namespace Model.Entity
{
    public class ReservaEsporadica : Reserva
    {


        public ReservaEsporadica(ReservaEsporadicaDTO esporadicaDTO, DiaEsporadica dia): base(esporadicaDTO)
        {
            this.DiaEsporadica = dia;
        }

        public ReservaEsporadica() { }

        public List<DiaEsporadica> DiaEsporadica { get; set; }
    }
}
