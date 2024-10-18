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

        public Bedel AddBedel(Bedel bedel)
        {
            _dbContext.Bedeles.Add(bedel);
            _dbContext.SaveChanges();
            return bedel;
        }

        public Bedel ObtenerPorId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del Bedel debe ser un número positivo.", nameof(id));
            }

            var bedel = _dbContext.Bedeles.Find(id);
            if (bedel == null)
            {
                throw new KeyNotFoundException($"No se encontró un Bedel con el ID {id}.");
            }

            return bedel;
        }
    }
}
