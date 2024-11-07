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
        public int piso { get; set; }
        [Required]
        [Column("aireAcondicionado")]
        public bool aireAcondicionado {  get; set; }
        [Required]
        [Column("estado")]
        public bool estado { get; set; }
        [Required]
        [Column("capacidad")]
        public int capacidad { get; set; }
        [Required]
        [Column("tipoDePizarron")]
        public Pizarron tipoDePizarron { get; set; }

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
