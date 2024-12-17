using Model.Abstract;
using Model.Entity;

namespace Data.DAO
{
    public interface IReservaDAO
    {
        void guardarReserva(Reserva reserva);
        List<ReservaEsporadica> obtenerReservasEsporadicas();
        List<ReservaPeriodica> obtenerReservasPeriodica();
    }
}