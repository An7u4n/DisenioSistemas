using Model.DTO;
namespace Services.ReservaService
{
    public interface IReservaService
    {
        List<List<AulaDTO>> ObtenerAulasParaReserva(ReservaEsporadicaDTO reservaEsporadicaDTO);
        void GuardarReservaPeriodica(ReservaPeriodicaDTO reservaPeriodicaDTO);
        void GuardarReservaEsporadica(ReservaEsporadicaDTO reservaEsporadicaDTO);
        ReservaDTO reservarAulas(ReservaDTO reservaDTO, List<DiaPeriodicaDTO> diaDTOs);
    }
}
