﻿using Model.DTO;
using Model.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model.Abstract
{
    public abstract class Reserva
    {

        [Key] [Column("idReserva")] private int idReserva { get; set; }
        [Required] [Column("profesor")] private string profesor { get; set; }
        [Required] [Column("nombreCatedra")] private string nombreCatedra { get; set; }

        [Required]
        [Column("correoElectronico")]
        private string correoElectronico { get; set; }

        public int idBedel { get; set; }
        public virtual Bedel Bedel { get; set; }
        
        

        public Reserva()
        {
        }

        public Reserva(ReservaDTO reservaDTO)
        {
            this.idReserva = reservaDTO.idReserva;
            this.profesor = reservaDTO.profesor;
            this.nombreCatedra = reservaDTO.nombreCatedra;
            this.correoElectronico = reservaDTO.correoElectronico;
            this.idBedel = reservaDTO.idBedel;
        }

        public Reserva(int idReserva, string profesor, string nombreCatedra, string correoElectronico)
        {
            this.idReserva = idReserva;
            this.profesor = profesor;
            this.nombreCatedra = nombreCatedra;
            this.correoElectronico = correoElectronico;
        }

        public int getId()
        {
            return idReserva;
        }

        public void setId(int id)
        {
            this.idReserva = id;
        }

        public string getProfesor()
        {
            return profesor;
        }

        public void setProfesor(string profesor)
        {
            this.profesor = profesor;
        }

        public string getNombreCatedra()
        {
            return nombreCatedra;
        }

        public void setNombreCatedra(string nombreCatedra)
        {
            this.nombreCatedra = nombreCatedra;
        }

        public string getCorreoElectronico()
        {
            return correoElectronico;
        }

        public void setCorreoElectronico(string correoElectronico)
        {
            this.correoElectronico = correoElectronico;
        }
    }
}
