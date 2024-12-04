using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AulaSinRecursosAdicionalesDTO : AulaDTO
    {

        public bool poseeVentiladores;

        public AulaSinRecursosAdicionalesDTO(int idAula, int numero, int piso, bool aireAcondicionado, bool estado, int capacidad, Pizarron tipoDePizarron, bool poseeVentiladores) : base(idAula, numero, piso, aireAcondicionado, estado, capacidad, tipoDePizarron)
        {
            this.poseeVentiladores = poseeVentiladores;
        }
    }
}