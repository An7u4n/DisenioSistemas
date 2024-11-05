using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisenioSistemas.Model.Abstract;

namespace Model.Entity{

    public class Administrador : Usuario
    {

        private int idAdministrador;

        
        public Administrador(string usuario,string contrasena): base(usuario, contrasena){}
        public override int getId()
        {
            return idAdministrador;
        }
    }


}