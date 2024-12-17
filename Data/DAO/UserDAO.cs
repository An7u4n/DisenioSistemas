using Data.Utilities;
using DisenioSistemas.Model.Abstract;
using DisenioSistemas.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Model.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.DAO
{
    public class UserDAO
    {
        private readonly AppDbContext _dbContext;

        public UserDAO(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario obtenerUsuario(string usuario)
        {
            var user = _dbContext.Usuarios
                                .AsEnumerable()
                                .Where(u => u.getUsuario() == usuario)
                                .SingleOrDefault();

            if (user == null)
            {
                throw new NotFoundException("No existe el usuario");
            }

            return user;
        }

        public List<Bedel> GetBedeles()
        {
            var bedeles = _dbContext.Bedeles.ToList();
            if (bedeles == null || !bedeles.Any()) throw new NotFoundException("No existen bedeles");
            return bedeles;
        }

        public List<Administrador> GetAdministradores()
        {
            var administradores = _dbContext.Administradores.ToList();
            if (administradores == null || !administradores.Any()) throw new Exception("No existen administradores");
            return administradores;
        }

        public Bedel guardarUsuarioBedel(Bedel bedel)
        {
            _dbContext.Bedeles.Add(bedel);
            _dbContext.SaveChanges();
            return bedel;
        }

        public Bedel obtenerUsuarioBedel(string usuario)
        {
            var bedel = _dbContext.Bedeles
                      .AsEnumerable()
                      .FirstOrDefault(b => b.getUsuario() == usuario);
            if (bedel == null) throw new NotFoundException("No existe el bedel");
            return bedel;
        }
        public List<Bedel> buscarBedeles(string apellido, Turno? turno)
        {
            var query = _dbContext.Bedeles.AsEnumerable().Where(b => b.getEstado() == true);  
            
            if (!string.IsNullOrEmpty(apellido))
            {
                query = query.Where(b => b.getApellido().Contains(apellido));
            }

            if (turno.HasValue)
            {
                query = query.Where(b => b.getTurno() == turno.Value);
            }

            var bedeles = query.Distinct().ToList();
            if (!bedeles.Any() || bedeles == null) throw new NotFoundException("Bedeles no encontrados");
            return bedeles;
        }
        public Bedel marcarEliminado(Bedel bedel)
        {
            bedel.setEstado(false);
            _dbContext.Bedeles.Update(bedel);
            _dbContext.SaveChanges();
            return bedel;
        }
        public Bedel actualizarBedel(Bedel bedel)
        {
            _dbContext.Bedeles.Update(bedel);
            _dbContext.SaveChanges();
            return bedel;
        }

        public Usuario guardarUsuarioAdmin(Administrador usuario)
        {
            _dbContext.Administradores.Add(usuario);
            _dbContext.SaveChanges();
            return usuario;
        }
    }
}
