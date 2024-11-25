using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Abstract
{
    public abstract class Reserva
    {
       
        [Key]
        private int idReserva { get; set; }
        [Required]
        [Column("profesor")]
        private string profesor { get; set; }
        [Required]
        [Column("nombreCatedra")]
        private string nombreCatedra { get; set; }
        [Required]
        [Column("correoElectronico")]
        private string correoElectronico { get; set; }

        public Reserva()
        {
        }

        public Reserva(int idReserva, string profesor, string nombreCatedra, string correoElectronico)
        {
            this.idReserva = idReserva;
            this.profesor = profesor;
            this.nombreCatedra = nombreCatedra;
            this.correoElectronico = correoElectronico;
        }

        
    }
}
