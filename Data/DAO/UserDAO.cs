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
    }
}
