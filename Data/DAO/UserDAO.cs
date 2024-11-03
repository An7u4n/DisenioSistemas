using DisenioSistemas.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace Data.DAO
{
    public class UserDAO
    {
        private readonly AppDbContext _dbContext;

        public UserDAO(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Bedel> GetBedeles()
        {
            var bedeles = _dbContext.Bedeles.ToList();
            if (bedeles == null || !bedeles.Any()) throw new Exception("No existen bedeles");
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

        public Bedel obtenerUsuario(string usuario)
        {
            var bedel = _dbContext.Bedeles
                      .AsEnumerable()  // Evalúa en el cliente después de traer los datos de la BD
                      .FirstOrDefault(b => b.getUsuario() == usuario);
            if (bedel == null) throw new Exception("No existe el bedel");
            return bedel;
        }
        public List<Bedel> buscarBedeles(string apellido, Turno? turno)
        {
            var query = _dbContext.Bedeles.AsEnumerable();  
            
            if (!string.IsNullOrEmpty(apellido))
            {
                query = query.Where(b => b.getApellido().Contains(apellido));
            }

            if (turno.HasValue)
            {
                query = query.Where(b => b.getTurno() == turno.Value);
            }

            var bedeles = query.Distinct().ToList();

            return bedeles;
        }
    }
}
