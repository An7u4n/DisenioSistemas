using Model.DTO;

namespace Services.ReservaService.Interfaces
{
    public interface IValidarCamposReserva
    {
        void ValidarCamposReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
        void ValidarCamposReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
    }
}
