using Model.DTO;

using Model.Abstract;
using Model.DTO;
using Model.Entity;
using Model.Enums;

namespace Services.AulaService
{
    public interface IAulaService
    {
        AulaDTO ConvertirADTO(Aula aula);
        double CalcularHorasSolapadas(TimeOnly inicio1, TimeOnly fin1, TimeOnly inicio2, TimeOnly fin2);
        List<DiaPeriodicaDTO> ConvertirDiasPeriodicos(IEnumerable<DiaPeriodica> diasPeriodicos);
        ICollection<DiaEsporadicaDTO> ConvertirDiasEsporadicos(IEnumerable<DiaEsporadica> diasEsporadicos);
        ReservaDTO ConvertirReservaADTO(Reserva reserva);
        List<SuperposicionInfoDTO> CalcularSuperposicion(DateTime dia, TimeOnly horaInicio, TimeOnly horaFin, Aula aula);
        List<DisponibilidadAulaDTO> comprobarDisponibilidadAulasEsporadica(List<DiaEsporadicaDTO> dias, List<Aula> aulas);
        List<DisponibilidadAulaDTO> obtenerAulasEsporadica(ReservaEsporadicaDTO reserva);
        List<SuperposicionInfoDTO> CalcularSuperposicionPeriodica(DiaSemana diaSemana, TimeOnly horaInicio, TimeOnly horaFin, Aula aula);
        List<DisponibilidadAulaDTO> comprobarDisponibilidadAulasPeriodica(List<DiaPeriodicaDTO> dias, List<Aula> aulas);
        List<DisponibilidadAulaDTO> obtenerAulasPeriodica(ReservaPeriodicaDTO reserva);
        List<DisponibilidadAulaDTO> obtenerAulas(ReservaDTO reserva);
    }
}
