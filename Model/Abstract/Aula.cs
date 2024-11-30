using Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Abstract
{
    public abstract class Aula
    {
        [Key]
        protected int idAula { get; set; }
        [Required]
        [Column("numero")]
        private int numero { get; set; }
        [Required]
        [Column("piso")]
        private int piso { get; set; }
        [Required]
        [Column("aireAcondicionado")]
        private bool aireAcondicionado {  get; set; }
        [Required]
        [Column("estado")]
        private bool estado { get; set; }
        [Required]
        [Column("capacidad")]
        private int capacidad { get; set; }
        [Required]
        [Column("tipoDePizarron")]
        private Pizarron tipoDePizarron { get; set; }

        public int idDia { get; set; }
        public virtual Dia Dia { get; set; }

        public Aula() { }
        public Aula(int numero, int piso, bool aireAcondicionado, bool estado, int capacidad, Pizarron tipoDePizarron)
        {
            this.numero = numero;
            this.piso = piso;
            this.aireAcondicionado = aireAcondicionado;
            this.estado = estado;
            this.capacidad = capacidad;
            this.tipoDePizarron = tipoDePizarron;
        }
    }
}
