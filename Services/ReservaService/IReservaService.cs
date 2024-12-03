using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ReservaService
{
    public interface IReservaService
    {
        ReservaEsporadicaDTO GuardarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
        ReservaPeriodicaDTO GuardarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
        ReservaDTO reservarAulas(List<AulaDTO> aulaDTOs);
    }
}
