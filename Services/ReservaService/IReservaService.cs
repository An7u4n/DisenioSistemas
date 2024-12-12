using Model.DTO;
namespace Services.ReservaService
{
    public interface IReservaService
    {
        List<List<AulaDTO>> ObtenerAulasParaReserva(ReservaEsporadicaDTO reservaEsporadicaDTO);
        ReservaPeriodicaDTO GuardarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
        void GuardarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
        ReservaDTO reservarAulas(ReservaDTO reservaDTO, List<DiaPeriodicaDTO> diaDTOs);
    }
}
