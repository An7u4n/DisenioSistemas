using Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class ReservaDAO
    {
        private readonly AppDbContext _dbContext;
        public ReservaDAO(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Reserva guardarReserva(Reserva reserva)
        {
            throw new NotImplementedException();
        }
    }
}
