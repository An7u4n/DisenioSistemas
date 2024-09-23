


public abstract class Usuario{

    private string usuario;
    private bool estado;


    public Usuario(){
    }

    public Usuario(string usuario){
        this.usuario = usuario;
        this.estado = true;
    }
    public Usuario(string usuario,bool estado){
        this.usuario = usuario;
        this.estado = estado;
    }
    public abstract int getId();
    public string getUsuario(){
        return usuario;
    }
    public bool getEstado(){
        return estado;
    }

    public void setUsuario(string usuario){
        this.usuario = usuario;
    }
    public void setEstado(bool estado){
        this.estado = estado;
    }

    

}