using System.ComponentModel.DataAnnotations;
using DisenioSistemas.Model.Abstract;

namespace Model.Entity{

    public class Administrador : Usuario
    {   
        private int idAdministrador;

        public Administrador(string usuario,bool estado): base(usuario,estado){}
        public Administrador(string usuario): base(usuario){}
        public override int getId()
        {
            return idAdministrador;
        }
    }


}