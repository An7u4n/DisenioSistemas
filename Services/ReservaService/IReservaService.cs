using Model.DTO;
namespace Services.ReservaService
{
    public interface IReservaService
    {
        List<DisponibilidadAulaDTO> validarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
        List<DisponibilidadAulaDTO> validarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
        void guardarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
        void guardarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
        bool chequearDisponibilidadAulaReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
        bool chequearDisponibilidadAulaReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
    }
}
