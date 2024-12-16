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
    public class DiaEsporadica : Dia
    {
        [Required]
        [Column("dia")]
        public DateTime dia { get; set; }
        public int idReserva { get; set; }
        public virtual ReservaEsporadica ReservaEsporadica { get; set; }

        public DiaEsporadica()
        {
        }

        public DiaEsporadica(int idDia,int duracionMinutos, TimeOnly horaInicio, DiaSemana diaSemana, Aula aula, DateTime dia)
        : base(idDia,duracionMinutos, horaInicio, aula)
        {
            this.dia = dia;
            
        }

        public DiaEsporadica(DiaEsporadicaDTO diaDto, Aula aula) : base(diaDto.idDia, diaDto.duracionMinutos, TimeOnly.Parse(diaDto.horaInicio), aula)
        {
            this.dia = diaDto.fecha;
        }
    }
}
