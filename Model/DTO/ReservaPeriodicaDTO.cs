using Model.Enums;
namespace Model.DTO
{
    public class ReservaPeriodicaDTO : ReservaDTO
    {
        //TODO pasar a private
        public string fechaInicio {  get; set; }
        public string fechaFin { get; set; }
        public List<DiaPeriodicaDTO> dias { get; set; }

        public ReservaPeriodicaDTO() { }

        public ReservaPeriodicaDTO(int idReserva, string profesor, string nombreCatedra, string correoElectronico, TipoPeriodo tipoPeriodo, DateOnly fechaInicio, DateOnly fechaFin, int cantidad_alumnos, List<DiaPeriodicaDTO> diaDTOs, int idBedel)
            :base(idReserva, profesor,nombreCatedra, correoElectronico,tipoPeriodo, cantidad_alumnos, idBedel)
        {
            this.fechaInicio = fechaInicio.ToString();
            this.fechaFin = fechaFin.ToString();
            this.dias = diaDTOs;
        }
    }
}
