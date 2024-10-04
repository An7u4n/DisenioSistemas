using System.Dynamic;
using DisenioSistemas.Model.Abstract;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace Data.DAO{
    public class UserDAO{
        private readonly AppDbContext _dbContext;

        public UserDAO(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario GetUsuario(string usuario){
            var usuarioObtenido = _dbContext.Usuarios.FirstOrDefault(a => EF.Property<string>(a,"usuario") == usuario);
            if(usuarioObtenido == null) throw new Exception("No existe el usuario " + usuario);
            return usuarioObtenido;
        }

        public List<Bedel> getBedeles(){
            var bedeles = _dbContext.Usuarios.OfType<Bedel>().ToList();
            if(bedeles == null || !bedeles.Any()) throw new Exception("No existen bedeles");
            return bedeles;
        }
        
        public List<Administrador> getAdministradores(){
            var administradores = _dbContext.Usuarios.OfType<Administrador>().ToList();
            if(administradores == null || !administradores.Any()) throw new Exception("No existen Administradores");
            return administradores;
        }


    }


}