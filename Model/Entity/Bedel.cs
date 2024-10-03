using System.ComponentModel.DataAnnotations;
using DisenioSistemas.Model.Abstract;
using DisenioSistemas.Model.Enums;

namespace Model.Entity{
public class Bedel : Usuario {

    [Key] private int idBedel;
    private string apellido;
    private string nombre;
    private Turno turno;
    
    public Bedel(string usuario, string apellido, string nombre, Turno turno) :base (usuario){
        this.apellido=apellido;
        this.nombre=nombre;
        this.turno=turno;
    }
    public Bedel(string usuario, bool estado, string apellido, string nombre, Turno turno) :base (usuario,estado){
        this.apellido=apellido;
        this.nombre=nombre;
        this.turno=turno;
    }
    public override int getId()
    {
        return idBedel;
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