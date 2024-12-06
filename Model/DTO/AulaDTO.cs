using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AulaDTO
    {

        public AulaDTO() { }
        protected AulaDTO(int idAula, int numero, int piso, bool aireAcondicionado, bool estado, int capacidad, Pizarron tipoDePizarron)
        {
            this.idAula = idAula;
            this.numero = numero;
            this.piso = piso;
            this.aireAcondicionado = aireAcondicionado;
            this.estado = estado;
            this.capacidad = capacidad;
            this.tipoDePizarron = tipoDePizarron;
        }

        public int idAula { get; set; }
        public int numero { get; set; }
        public int piso { get; set; }
        public bool aireAcondicionado { get; set; }
        public bool estado { get; set; }
        public int capacidad { get; set; }
        public Pizarron tipoDePizarron { get; set; }
            
        

    }
}
