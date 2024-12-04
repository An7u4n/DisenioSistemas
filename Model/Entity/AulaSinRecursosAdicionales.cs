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
        //getters and setters
        public int getIdAula()
        {
            return this.idAula;
        }

        public void setIdAula(int idAula)
        {
            this.idAula = idAula;
        }

        public bool getPoseeVentiladores()
        {
            return poseeVentiladores;
        }

        public void setPoseeVentiladores(bool poseeVentiladores)
        {
            this.poseeVentiladores = poseeVentiladores;
        }
    }
}
