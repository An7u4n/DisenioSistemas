using System.ComponentModel.DataAnnotations;
using DisenioSistemas.Model.Abstract;
using DisenioSistemas.Model.Enums;
using Model.Abstract;

namespace Model.Entity{
public class Bedel : Usuario {

        [Required]
        private string apellido;
        [Required]
        private string nombre;
        [Required]
        private Turno turno;

        public ICollection<Reserva> Reservas;
    
        public Bedel(string usuario,string contrasena, string apellido, string nombre, Turno turno) :base (usuario,contrasena){
            this.apellido=apellido;
            this.nombre=nombre;
            this.turno=turno;
        }

        public string getApellido(){
            return apellido;
        }
        public void setApellido(string apellido){
            this.apellido = apellido;
        }
        public string getNombre(){
            return nombre;
        }
        public void setNombre(string nombre){
            this.nombre=nombre;
        }
        public Turno getTurno(){
            return turno;
            }
        public void setTurno(Turno turno){
            this.turno=turno;
        }

   

}

}