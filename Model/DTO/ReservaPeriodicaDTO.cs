using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class ReservaPeriodicaDTO : ReservaDTO
    {
        [Required(ErrorMessage = "Seleccione fecha de inicio")]
        private DateOnly fechaInicio {  get; set; }
        [Required(ErrorMessage = "Seleccione fecha de fin")]
        private DateOnly fechaFin { get; set; }

        [Required(ErrorMessage = "Seleccione los dias a reservar")]
        private List<DiaDTO> diaDTOs { get; set; }

        public ReservaPeriodicaDTO(int idReserva, string profesor, string nombreCatedra, string correoElectronico, TipoPeriodo tipoPeriodo, DateOnly fechaInicio, DateOnly fechaFin, List<DiaDTO> diaDTOs)
            :base(idReserva, profesor,nombreCatedra, correoElectronico,tipoPeriodo)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.diaDTOs = diaDTOs;
        }
    }
}
