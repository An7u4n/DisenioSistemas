using Model.Abstract;
using Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    public class AulaSinRecursosAdicionales : Aula
    {
        [Key]
        private int idAula;
        [Required]
        [Column("poseeVentiladores")]
        private bool poseeVentiladores;

        public AulaSinRecursosAdicionales() { }
        public AulaSinRecursosAdicionales(int numero, int piso, bool aireAcondicionado, bool estado, int capacidad, Pizarron tipoDePizarron, bool poseeVentiladores)
            : base(numero, piso, aireAcondicionado, estado, capacidad, tipoDePizarron)
        {
            this.poseeVentiladores = poseeVentiladores;
        }
    }
}
