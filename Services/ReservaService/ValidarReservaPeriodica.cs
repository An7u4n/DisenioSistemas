using Model.DTO;
using Services.ReservaService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ReservaService
{
    public class ValidarReservaPeriodica : IValidarReserva<ReservaPeriodicaDTO>
    {
        private readonly IValidarCamposReserva _validarCamposReserva;

        public ValidarReservaPeriodica(IValidarCamposReserva validarCamposReserva)
        {
            _validarCamposReserva = validarCamposReserva;
        }

        public void ValidarReserva(ReservaPeriodicaDTO reserva)
        {
            _validarCamposReserva.ValidarCamposReservaPeriodica(reserva);
        }
    }
}
