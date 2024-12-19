using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Cuatrimestre
    {
        [Key]
        private int IdCuatrimestre { get; set; }
        [Column("idCuatrimestre")]
        private int numeroCuatrimestre { get; set; }
        [Column("fechaInicio")]
        private DateOnly fechaInicio { get; set; }
        [Column("fechaFin")]
        private DateOnly fechaFin { get; set; }
        [Column("idAnio")]
        public virtual AnioLectivo anioLectivo { get; set; }
        public virtual ICollection<ReservaPeriodica> ReservaPeriodica { get; set; }
        public Cuatrimestre() { }

        public Cuatrimestre(int numeroCuatrimestre, DateOnly fechaInicio, DateOnly fechaFin, AnioLectivo anioLectivo)
        {
            this.numeroCuatrimestre = numeroCuatrimestre;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.anioLectivo = anioLectivo;
        }

        public int getNumeroCuatrimestre() => numeroCuatrimestre;

        public DateOnly getFechaInicio => fechaInicio;
        public DateOnly getFechaFin => fechaFin;

        public int GetIdCuatrimestre() => IdCuatrimestre;
    }
}
