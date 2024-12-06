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

        public virtual HashSet<Dia> Dias { get; set; }

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

        [NotMapped]
        public int IdAula { get { return idAula; }}
        [NotMapped]
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        [NotMapped]
        public int Piso
        {
            get { return piso; }
            set { piso = value; }
        }
        [NotMapped]
        public bool AireAcondicionado
        {
            get { return aireAcondicionado; }
            set { aireAcondicionado = value; }
        }
        [NotMapped]
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        [NotMapped]
        public int Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }
        }
        [NotMapped]
        public Pizarron TipoDePizarron
        {
            get { return tipoDePizarron; }
            set { tipoDePizarron = value; }
        }
    }
}
