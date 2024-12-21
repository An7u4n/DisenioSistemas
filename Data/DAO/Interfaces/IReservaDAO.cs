using Model.Abstract;
using Model.Entity;

namespace Data.DAO.Interfaces
{
    public interface IReservaDAO
    {
        void guardarReserva(Reserva reserva);
        List<ReservaEsporadica> obtenerReservasEsporadicas();
        List<ReservaPeriodica> obtenerReservasPeriodica();
    }
}