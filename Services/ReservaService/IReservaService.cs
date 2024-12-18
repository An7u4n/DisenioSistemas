using Model.DTO;
namespace Services.ReservaService
{
    public interface IReservaService
    {
        List<DisponibilidadAulaDTO> validarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
        List<DisponibilidadAulaDTO> validarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
        void guardarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
        void guardarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
        public void ConfirmarDisponibilidadAulaParaReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
        public void ConfirmarDisponibilidadAulaParaReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
        public void validarCamposEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
        public void validarCamposPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);

    }
}
