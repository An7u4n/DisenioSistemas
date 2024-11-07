using Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Abstract
{
    public abstract class Dia
    {
        [Key]
        public int idDia { get; set; }
        [Required]
        [Column("duracionMinutos")]
        private int duracionMinutos { get; set; }
        [Required]
        [Column("horaInicio")]
        private TimeOnly horaInicio { get; set; }
        [Required]
        [Column("diaSemana")]
        private DiaSemana diaSemana { get; set; }
        [Required]
        [Column("idAula")]
        private int idAula { get; set; }
        public virtual Aula aula { get; set; }
    }
}
