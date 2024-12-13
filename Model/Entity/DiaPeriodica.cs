using Model.Abstract;
using Model.DTO;
using Model.Enums;
namespace Model.Entity
{
    public class DiaPeriodica : Dia
    {
        public int idReserva { get; set; }
        private DiaSemana diaSemana { get; set; }
        public virtual ReservaPeriodica ReservaPeriodica { get; set; }

        public DiaSemana getDiaSemana()
        {
            return diaSemana;
        }

        public DiaPeriodica() : base()
        {
        }

        public DiaPeriodica(int idDia,int duracionMinutos, TimeOnly horaInicio, DiaSemana diaSemana, Aula aula)
       : base(idDia,duracionMinutos, horaInicio, aula)
        {
            this.diaSemana = diaSemana;
        }

        public DiaPeriodica(DiaPeriodicaDTO diaDto, Aula aula) : base(diaDto.idDia, diaDto.duracionMinutos, TimeOnly.Parse(diaDto.horaInicio), aula)
        {
            this.diaSemana = diaDto.diaSemana;
        }
    }
}
