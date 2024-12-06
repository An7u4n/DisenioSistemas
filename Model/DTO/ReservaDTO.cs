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
        public int idReserva { get; set; }
        [Required(ErrorMessage = "El profesor es obligatorio.")]
        public string profesor { get; set; }
        [Required(ErrorMessage = "El nombre de la catedra es obligatorio")]
        public string nombreCatedra { get; set; }
        [Required(ErrorMessage = "El correo electronico es obligatorio")]
        public string correoElectronico { get; set; }

        [Required(ErrorMessage = "Seleccione periodo")]
        public TipoPeriodo tipoPeriodo { get; set; }

        public HashSet<AulaDTO> aulas { get; set; }
        public int cantidad_alumnos { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }

        public Dictionary<DiaSemana, Tuple<TimeOnly, int>> horariosPorDia;


        public ReservaDTO(int idReserva, string profesor, string nombreCatedra, string correoElectronico, TipoPeriodo tipoPeriodo)
        {
            this.idReserva = idReserva;
            this.profesor = profesor;
            this.nombreCatedra = nombreCatedra;
            this.correoElectronico = correoElectronico;
            this.tipoPeriodo = tipoPeriodo;
        }
    }
}
