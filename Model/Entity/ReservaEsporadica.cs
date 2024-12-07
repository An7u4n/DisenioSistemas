using Model.Abstract;
using Model.DTO;
namespace Model.Entity
{
    public class ReservaEsporadica : Reserva
    {

        public ReservaEsporadica(ReservaEsporadicaDTO esporadicaDTO): base(esporadicaDTO)
        {
            
        }

        public ReservaEsporadica() { }

        public DiaEsporadica DiaEsporadica { get; set; }
    }
}
