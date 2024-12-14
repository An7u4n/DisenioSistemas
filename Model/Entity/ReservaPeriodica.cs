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
        //TODO Ojo con esto hay que hacer un embole
        public int idCuatrimestre { get; set; }


        public List<DiaPeriodica> DiasPeriodica { get; set;}
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
            this.tipoPeriodo = reservaDTO.tipoPeriodo;
            this.fechaInicio = DateTime.Parse(reservaDTO.fechaInicio);
            this.fechaFin= DateTime.Parse(reservaDTO.fechaFin);
            this.DiasPeriodica = new List<DiaPeriodica>();
        }
        
        public void addDia(DiaPeriodica dia)
        {
            DiasPeriodica.Add(dia);
        }
        public void removeDia(DiaPeriodica dia)
        {
            DiasPeriodica.Remove(dia);
        }
        public TipoPeriodo getTipoPeriodo()
        {
            return tipoPeriodo;
        }
        public void setTipoPeriodo(TipoPeriodo tipoPeriodo)
        {
            this.tipoPeriodo = tipoPeriodo;
        }
        public DateTime getFechaInicio()
        {
            return fechaInicio;
        }
        public void setFechaInicio(DateTime fechaInicio)
        {
            this.fechaInicio = fechaInicio;
        }
        public DateTime getFechaFin()
        {
            return fechaFin;
        }
        public void setFechaFin(DateTime fechaFin)
        {
            this.fechaFin = fechaFin;
        }
        public Cuatrimestre getCuatrimestre()
        {
            return cuatrimestre;
        }
        public void setCuatrimestre(Cuatrimestre cuatrimestre)
        {
            this.cuatrimestre = cuatrimestre;
        }
    }
}
