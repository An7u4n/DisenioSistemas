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
    public class AulaMultimediosDTO : AulaDTO
    {
        public AulaMultimediosDTO(int idAula, int numero, int piso, bool aireAcondicionado, bool estado, int capacidad, Pizarron tipoDePizarron, bool televisor, bool poseeVentiladores, bool canion, int cantidadComputadoras) : base(idAula, numero, piso, aireAcondicionado, estado, capacidad, tipoDePizarron)
        {
            this.televisor = televisor;
            this.poseeVentiladores = poseeVentiladores;
            this.canion = canion;
            this.cantidadComputadoras = cantidadComputadoras;
        }

        public bool televisor { get; set; }
        public bool poseeVentiladores { get; set; }
        public bool canion { get; set; }
        public int cantidadComputadoras { get; set; }


    }
}