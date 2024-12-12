using Model.Enums;
namespace Model.DTO
{
    public class ReservaPeriodicaDTO : ReservaDTO
    {
        private DateOnly fechaInicio {  get; set; }
        private DateOnly fechaFin { get; set; }
        private List<DiaPeriodicaDTO> diaDTOs { get; set; }

        public ReservaPeriodicaDTO(int idReserva, string profesor, string nombreCatedra, string correoElectronico, TipoPeriodo tipoPeriodo, DateOnly fechaInicio, DateOnly fechaFin, int cantidad_alumnos, List<DiaPeriodicaDTO> diaDTOs)
            :base(idReserva, profesor,nombreCatedra, correoElectronico,tipoPeriodo, cantidad_alumnos)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.diaDTOs = diaDTOs;
        }
    }
}
