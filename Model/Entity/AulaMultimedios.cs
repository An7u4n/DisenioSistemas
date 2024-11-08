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
    }
}
