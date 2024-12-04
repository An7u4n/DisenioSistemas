using Data.Utilities;
using Microsoft.EntityFrameworkCore;
using Model.Abstract;
using Model.Entity;
using Model.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Data.DAO
{
    public class AulaDAO
    {
        private readonly AppDbContext _dbContext;

        public AulaDAO(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       public AulaMultimedios obtenerAulaMultimedios(int idAula)
        {
            var aula = _dbContext.AulasMultimedios
                      .AsEnumerable()
                      .FirstOrDefault(a => a.getIdAula() == idAula);
            if (aula == null) throw new NotFoundException("No existe el aula");
            return aula;
        }
       public AulaInformatica obtenerAulaInformatica(int idAula)
        {
            var aula = _dbContext.AulasInformatica
                      .AsEnumerable()
                      .FirstOrDefault(a => a.getIdAula() == idAula);
            if (aula == null) throw new NotFoundException("No existe el aula");
            return aula;
        }
       public AulaSinRecursosAdicionales obtenerAulaSinRecursosAdicionales(int idAula)
        {
            var aula = _dbContext.AulasSinRecursosAdicionales
                      .AsEnumerable()
                      .FirstOrDefault(a => a.getIdAula() == idAula);
            if (aula == null) throw new NotFoundException("No existe el aula");
            return aula;
        }

        public AulaInformatica guardarAulaInformatica(AulaInformatica aulaInformatica)
        {
            _dbContext.AulasInformatica.Add(aulaInformatica);
            _dbContext.SaveChanges();
            return aulaInformatica;
        }
        public AulaMultimedios guardarAulaMultimedios(AulaMultimedios aulaMultimedios)
        {
            _dbContext.AulasMultimedios.Add(aulaMultimedios);
            _dbContext.SaveChanges();
            return aulaMultimedios;
        }

        public AulaSinRecursosAdicionales guardarAulaSinRecursosAdicionales(AulaSinRecursosAdicionales aulaSinRecursosAdicionales)
        {
            _dbContext.AulasSinRecursosAdicionales.Add(aulaSinRecursosAdicionales);
            _dbContext.SaveChanges();
            return aulaSinRecursosAdicionales;
        }

        public AulaInformatica actualizarAulaInformatica(AulaInformatica aulaInformatica)
        {
            _dbContext.AulasInformatica.Update(aulaInformatica);
            _dbContext.SaveChanges();
            return aulaInformatica;
        }

        public AulaMultimedios actualizarAulaMultimedios(AulaMultimedios aulaMultimedios)
        {
            _dbContext.AulasMultimedios.Update(aulaMultimedios);
            _dbContext.SaveChanges();
            return aulaMultimedios;
        }

        public AulaSinRecursosAdicionales actualizarAulaSinRecursosAdicionales(AulaSinRecursosAdicionales aulaSinRecursosAdicionales)
        {
            _dbContext.AulasSinRecursosAdicionales.Update(aulaSinRecursosAdicionales);
            _dbContext.SaveChanges();
            return aulaSinRecursosAdicionales;
        }

    }
}
