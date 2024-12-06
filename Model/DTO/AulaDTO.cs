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
        public AulaDTO(int idAula, int numero, int piso, bool aireAcondicionado, bool estado, int capacidad, Pizarron tipoDePizarron)
        {
            this.idAula = idAula;
            this.numero = numero;
            this.piso = piso;
            this.aireAcondicionado = aireAcondicionado;
            this.estado = estado;
            this.capacidad = capacidad;
            this.tipoDePizarron = tipoDePizarron;
        }

        protected int idAula { get; set; }
        private int numero { get; set; }
        private int piso { get; set; }
        private bool aireAcondicionado { get; set; }
        private bool estado { get; set; }
        private int capacidad { get; set; }
        private Pizarron tipoDePizarron { get; set; }
            
        

    }
}