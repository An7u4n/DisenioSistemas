using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public abstract class ReservaDTO
    {
        private int idReserva { get; set; }
        [Required(ErrorMessage = "El profesor es obligatorio.")]
        private string profesor { get; set; }
        [Required(ErrorMessage = "El nombre de la catedra es obligatorio")]
        private string nombreCatedra { get; set; }
        [Required(ErrorMessage = "El correo electronico es obligatorio")]
        private string correoElectronico { get; set; }

        [Required(ErrorMessage = "Seleccione periodo")]
        private TipoPeriodo tipoPeriodo { get; set; }

        protected ReservaDTO(int idReserva, string profesor, string nombreCatedra, string correoElectronico, TipoPeriodo tipoPeriodo)
        {
            this.idReserva = idReserva;
            this.profesor = profesor;
            this.nombreCatedra = nombreCatedra;
            this.correoElectronico = correoElectronico;
            this.tipoPeriodo = tipoPeriodo;
        }
    }
}
