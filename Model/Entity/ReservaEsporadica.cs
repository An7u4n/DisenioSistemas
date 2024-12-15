using Model.Abstract;
using Model.DTO;
namespace Model.Entity
{
    public class ReservaEsporadica : Reserva
    {

        public ReservaEsporadica(ReservaEsporadicaDTO esporadicaDTO, DiaEsporadica dia): base(esporadicaDTO)
        {
            this.DiaEsporadica = dia;
        }

        public ReservaEsporadica() { }

        public DiaEsporadica DiaEsporadica { get; set; }
    }
}
