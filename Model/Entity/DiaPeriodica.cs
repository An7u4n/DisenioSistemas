using Model.Abstract;
using Model.DTO;
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
        private DiaPeriodicaDTO diaDto;

        public int idReserva { get; set; }
        public virtual ReservaPeriodica ReservaPeriodica { get; set; }

        public DiaPeriodica() : base()
        {
        }

        public DiaPeriodica(int idDia,int duracionMinutos, TimeOnly horaInicio, DiaSemana diaSemana, Aula aula)
       : base(idDia,duracionMinutos, horaInicio, aula)
        {
           
        }

        public DiaPeriodica(DiaPeriodicaDTO diaDto)
        {
            this.diaDto = diaDto;
        }
    }
}
