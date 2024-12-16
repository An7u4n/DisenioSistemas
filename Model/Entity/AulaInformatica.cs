using Model.Abstract;
using Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    public class AulaInformatica : Aula
    {
        [Key]
        private int idAula;
        [Required]
        [Column("canion")]
        private bool canion;
        [Required]
        [Column("cantidadComputadoras")]
        private int cantidadComputadoras;

        public AulaInformatica() { }
        public AulaInformatica(int numero, int piso, bool aireAcondicionado, bool estado, int capacidad, Pizarron tipoDePizarron, bool canion, int cantidadComputadoras)
            : base(numero, piso, aireAcondicionado, estado, capacidad, tipoDePizarron)
        {
            this.canion = canion;
            this.cantidadComputadoras = cantidadComputadoras;
        }
        public int getIdAula()
        {
            return base.idAula;
        }

        public void setIdAula(int idAula)
        {
            this.idAula = idAula;
        }

        public bool getCanion()
        {
            return canion;
        }

        public void setCanion(bool canion)
        {
            this.canion = canion;
        }

        public int getCantidadComputadoras()
        {
            return cantidadComputadoras;
        }

        public void setCantidadComputadoras(int cantidadComputadoras)
        {
            this.cantidadComputadoras = cantidadComputadoras;
        }

        
    }
}
