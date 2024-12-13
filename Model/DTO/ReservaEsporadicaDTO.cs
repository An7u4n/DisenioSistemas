using Model.Enums;
namespace Model.DTO
{
    public class ReservaEsporadicaDTO : ReservaDTO
    {
        public ICollection<DiaEsporadicaDTO> dias { get; set; }

        public ReservaEsporadicaDTO() { }
        public ReservaEsporadicaDTO(int idReserva, string profesor, string nombreCatedra, string correoElectronico, TipoPeriodo tipoPeriodo, int cantidad_alumnos, int idBedel)
           :base(idReserva, profesor, nombreCatedra, correoElectronico, tipoPeriodo, cantidad_alumnos, idBedel)
        {
        }
    }
}
