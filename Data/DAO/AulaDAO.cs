using Microsoft.EntityFrameworkCore;
using Model.Abstract;

namespace Data.DAO
{
    public class AulaDAO
    {
        private readonly AppDbContext _dbContext;

        public AulaDAO(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public HashSet<Aula> getAulasByTipo<T>() where T : Aula
        { 
            var aulas = _dbContext.Aulas
                .Where(a => a is T)
                .ToHashSet();

            return aulas;
        }

       public ICollection<Aula> ObtenerAulas()
       {
            return _dbContext.Aulas.Include(a => a.Dias).ToList();
       }

        public Aula ObtenerAula(int numeroAula)
        {
            return _dbContext.Aulas.ToList().FirstOrDefault(a => a.getNumero() == numeroAula);
        }
    }
}
