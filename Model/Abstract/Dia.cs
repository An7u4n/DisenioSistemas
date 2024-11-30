using Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Abstract
{
    public abstract class Dia
    {
        
        [Key]
        private int idDia { get; set; }
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
        public int idAula { get; set; }
        public virtual Aula Aula { get; set; }
        
        

       
        

        public Dia()
        {
        }

        protected Dia(int idDia, int duracionMinutos, TimeOnly horaInicio, DiaSemana diaSemana, Aula aula)
        {
            this.idDia = idDia;
            this.duracionMinutos = duracionMinutos;
            this.horaInicio = horaInicio;
            this.diaSemana = diaSemana;
            this.Aula = aula;
        }
    }
}
