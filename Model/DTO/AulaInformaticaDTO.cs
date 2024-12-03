using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.DTO
{
    public class AulaInformaticaDTO : AulaDTO
    {
        private bool canion;
       
        private int cantidadComputadoras;

        public AulaInformaticaDTO(int idAula, int numero, int piso, bool aireAcondicionado, bool estado, int capacidad, Pizarron tipoDePizarron, bool canion, int cantidadComputadoras) : base(idAula, numero, piso, aireAcondicionado, estado, capacidad, tipoDePizarron)
        {
            this.canion = canion;
            this.cantidadComputadoras = cantidadComputadoras;
        }
    }
}
