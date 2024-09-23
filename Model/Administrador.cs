namespace DisenioSistemas.Model{

    public class Administrador : Usuario
    {   
        int idAdministrador;

        public Administrador(string usuario,bool estado): base(usuario,estado){}
        public Administrador(string usuario): base(usuario){}
        public override int getId()
        {
            return idAdministrador;
        }
    }


}