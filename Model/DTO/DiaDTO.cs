using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class DiaDTO
    {
        private int idDia { get; set; }
        [Required(ErrorMessage = "Seleccione el numero de aula")]
        private int numeroAula { get; set; }
        [Required(ErrorMessage = "Seleccione hora")]
        private TimeOnly horaInicio { get; set; }
        [Required(ErrorMessage = "Seleccione dia de la semana")]
        private DiaSemana diaSemana { get; set; }
    }
}
