using Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Abstract
{
    public abstract class Aula
    {
        [Key] protected int idAula;
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

        public virtual ICollection<Dia> Dias { get; set; }

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

        public int getIdAula()
        {
            return idAula;
        }
        public void setIdAula(int idAula)
        {
            this.idAula = idAula;
        }

        public int getNumero()
        {
            return numero;
        }
        public void setNumero(int numero)
        {
            this.numero = numero;
        }
   
        public int getPiso()
        {
            return piso;
        }
        public void setPiso(int piso)
        {
            this.piso = piso;
        }
     
        public bool getAireAcondicionado()
        {
            return aireAcondicionado;
        }
        public void setAireAcondicionado(bool aireAcondicionado)
        {
            this.aireAcondicionado = aireAcondicionado;
        }
        public bool getEstado()
        {
            return estado;
        }
        public void setEstado(bool estado)
        {
            this.estado = estado;
        }
        public int getCapacidad()
        {
            return capacidad;
        }
        public void setCapacidad(int capacidad)
        {
            this.capacidad = capacidad;
        }
        public Pizarron getTipoDePizarron()
        {
            return tipoDePizarron;
        }
        public void setTipoDePizarron(Pizarron tipoDePizarron)
        {
            this.tipoDePizarron = tipoDePizarron;
        }
    }
}
