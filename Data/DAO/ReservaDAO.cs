using Microsoft.EntityFrameworkCore;
using Model.Abstract;
using Model.Entity;
namespace Data.DAO
{
    public class ReservaDAO
    {
        private readonly AppDbContext _dbContext;
        public ReservaDAO(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void guardarReserva(Reserva reserva)
        {
            _dbContext.Reservas.Add(reserva);
            _dbContext.SaveChanges();
        }

        public List<ReservaEsporadica> obtenerReservasEsporadicas()
        {
            return _dbContext.ReservasEsporadica.Include(r => r.DiasEsporadica).ToList();
        }

        public List<ReservaPeriodica> obtenerReservasPeriodica()
        {
            return _dbContext.ReservasPeriodica.ToList();
        }
    }
}
