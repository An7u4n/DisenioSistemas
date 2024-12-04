using Model.Abstract;
using Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    public class AulaMultimedios : Aula
    {
        [Key]
        private int idAula;
        [Required]
        [Column("televisor")]
        private bool televisor;
        [Required]
        [Column("poseeVentiladores")]
        private bool poseeVentiladores;
        [Required]
        [Column("canion")]
        private bool canion;
        [Required]
        [Column("cantidadComputadoras")]
        private int cantidadComputadoras;

        public AulaMultimedios() { }
        public AulaMultimedios(int numero, int piso, bool aireAcondicionado, bool estado, int capacidad, Pizarron tipoDePizarron, bool televisor, bool poseeVentiladores, bool canion, int cantidadComputadoras)
            : base(numero, piso, aireAcondicionado, estado, capacidad, tipoDePizarron)
        {
            this.televisor = televisor;
            this.poseeVentiladores = poseeVentiladores;
            this.canion = canion;
            this.cantidadComputadoras = cantidadComputadoras;
        }
        public int getIdAula()
        {
            return idAula;
        }

        public void setIdAula(int idAula)
        {
            this.idAula = idAula;
        }

        public bool getTelevisor()
        {
            return televisor;
        }

        public void setTelevisor(bool televisor)
        {
            this.televisor = televisor;
        }

        public bool getPoseeVentiladores()
        {
            return poseeVentiladores;
        }

        public void setPoseeVentiladores(bool poseeVentiladores)
        {
            this.poseeVentiladores = poseeVentiladores;
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
