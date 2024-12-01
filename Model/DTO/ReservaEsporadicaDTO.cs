using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class ReservaEsporadicaDTO : ReservaDTO
    {
        [Required(ErrorMessage = "Seleccione dia")] 
        private DiaDTO dia { get; set; }

        public ReservaEsporadicaDTO(int idReserva, string profesor, string nombreCatedra, string correoElectronico, TipoPeriodo tipoPeriodo,DiaDTO dia) 
            :base(idReserva,profesor,nombreCatedra,correoElectronico,tipoPeriodo)
        {
            this.dia = dia;
        }
    }
}
