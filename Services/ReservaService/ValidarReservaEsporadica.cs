using Model.DTO;
using Services.ReservaService.Interfaces;

namespace Services.ReservaService
{
    public class ValidarReservaEsporadica : IValidarReserva<ReservaEsporadicaDTO>
    {
        private readonly IValidarCamposReserva _validarCamposReserva;

        public ValidarReservaEsporadica(IValidarCamposReserva validarCamposReserva)
        {
            _validarCamposReserva = validarCamposReserva;
        }

        public void ValidarReserva(ReservaEsporadicaDTO reserva)
        {
            _validarCamposReserva.ValidarCamposReservaEsporadica(reserva);
        }
    }
}
