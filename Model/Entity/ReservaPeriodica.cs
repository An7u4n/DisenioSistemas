using Model.Abstract;
using Model.DTO;
using Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    public class ReservaPeriodica : Reserva
    {
        [Column("idCuatrimestre")]
        private Cuatrimestre cuatrimestre {get;set;}
        [Column("fechaInicio")]
        private DateTime fechaInicio { get;set;}
        [Column("fechaFin")]
        private DateTime fechaFin { get;set;}
        [Column("periodo")]
        private TipoPeriodo tipoPeriodo { get;set;}

        public DiaPeriodica DiaPeriodica { get; set;}
        public ReservaPeriodica() { }

        public ReservaPeriodica(Cuatrimestre cuatrimestre, DateTime fechaInicio, DateTime fechaFin, TipoPeriodo tipoPeriodo)
        {
            this.cuatrimestre = cuatrimestre;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.tipoPeriodo = tipoPeriodo;
        }

        public ReservaPeriodica(ReservaPeriodicaDTO reservaDTO) : base(reservaDTO)
        {
        }
    }
}
