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
        public HashSet<Aula> getAulasByTipo(Type tipoAula)
        {
            if (tipoAula == null || !typeof(Aula).IsAssignableFrom(tipoAula))
            {
                throw new ArgumentException("El tipo especificado no es válido para aulas.");
            }

            // Obtener todas las aulas desde la base de datos
            var aulas = _dbContext.Aulas
                .Include(a => a.Dias) // Incluir los días relacionados
                .ToList();

            // Filtrar solo las aulas que sean del tipo especificado
            var aulasFiltradas = aulas
                .Where(a => tipoAula.IsInstanceOfType(a)) // Usar typeof para validar el tipo
                .ToHashSet();

            return aulasFiltradas;
        }
        
       public ICollection<Aula> ObtenerAulas()
       {
            return _dbContext.Aulas.Include(a => a.Dias).ToList();
       }

        public Aula ObtenerAula(int numeroAula)
        {
            return _dbContext.Aulas.ToList().FirstOrDefault(a => a.getNumero() == numeroAula);
        }
        
        public Aula ObtenerAulaPorNumero(int numeroAula)
        {
            return _dbContext.Aulas.ToList().FirstOrDefault(a => a.getNumero() == numeroAula);
        }
        public void GuardarAula(Aula aula)
        {
            _dbContext.Aulas.Add(aula);
            _dbContext.SaveChanges();
        }
    }
}
