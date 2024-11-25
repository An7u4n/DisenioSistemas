using Model.Abstract;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class DiaPeriodica : Dia
    {
        [Required]
        [Column("idResevaPeriodica")]
        public ReservaPeriodica reservaPeriodica { get; set; }

        public DiaPeriodica() : base()
        {
        }

        public DiaPeriodica(int idDia,int duracionMinutos, TimeOnly horaInicio, DiaSemana diaSemana, Aula aula, ReservaPeriodica reservaPeriodica)
       : base(idDia,duracionMinutos, horaInicio, diaSemana, aula)
        {
            this.reservaPeriodica = reservaPeriodica;
        }

    }
}
