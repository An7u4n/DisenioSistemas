using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisenioSistemas.Model.Abstract;

namespace Model.Entity{

    public class Administrador : Usuario
    {
        public Administrador(string usuario,string contrasena): base(usuario, contrasena){}

        
    }


}