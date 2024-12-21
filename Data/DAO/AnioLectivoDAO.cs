using Data.DAO.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class AnioLectivoDAO : IAnioLectivoDAO
    {
        private readonly AppDbContext _dbContext;
        public AnioLectivoDAO(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AnioLectivo GetAnioLectivo(string anio)
        {
            var anioLectivo = _dbContext.AnioLectivos.Include(a => a.Cuatrimestres).FirstOrDefault(a => EF.Property<string>(a, "Anio") == anio);
            if (anioLectivo == null) throw new Exception("No existe el año lectivo");
            return anioLectivo;
        }

        public void GuardarAnioLectivo(string anioLectivo)
        {
            _dbContext.AnioLectivos.Add(new AnioLectivo(anioLectivo));
            _dbContext.SaveChanges();
        }
    }
}
