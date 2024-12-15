using Model.DTO;
namespace Services.ReservaService
{
    public interface IReservaService
    {
        void validarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
        void validarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
        void guardarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
        void guardarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
    }
}
