using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisenioSistemas.Model.Abstract{


    public abstract class Usuario {

    [Key]
    protected int id;
    [Required]
    [Column("usuario")]
    private string usuario;
    [Required]
    [Column("contrasena")]
    private string contrasena;
    [Required]
    [Column("estado")]
    private bool estado;


    public Usuario(){
    }

    public Usuario(string usuario, string contrasena)
        {
            this.usuario = usuario;
            this.estado = true;
            this.contrasena = contrasena;
        }
        public Usuario(string usuario,bool estado){
        this.usuario = usuario;
        this.estado = estado;
    }
    public int getId()
        {
            return id;
        }
    public string getUsuario(){
        return usuario;
    }
    public bool getEstado(){
        return estado;
    }
    public string getContrasena()
        {
            return contrasena;
        }

    public void setUsuario(string usuario){
        this.usuario = usuario;
    }
    public void setEstado(bool estado){
        this.estado = estado;
    }
    public void setContrasena(string contrasena) {
            this.contrasena = contrasena;
     }
    


}
}