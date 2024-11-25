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
    public class DiaEsporadica : Dia
    {
        [Required]
        [Column("dia")]
        public DateTime dia { get; set; }
        [Required]
        [Column("idReservaEsporadica")]
        public ReservaEsporadica reservaEsporadica { get; set; }

        public DiaEsporadica()
        {
        }

        public DiaEsporadica(int idDia,int duracionMinutos, TimeOnly horaInicio, DiaSemana diaSemana, Aula aula, DateTime dia, ReservaEsporadica reservaEsporadica)
        : base(idDia,duracionMinutos, horaInicio, diaSemana, aula)
        {
            this.dia = dia;
            this.reservaEsporadica = reservaEsporadica;
        }

    }
}
