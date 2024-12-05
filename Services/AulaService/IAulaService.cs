using Model.DTO;

namespace Services.AulaService
{
    public interface IAulaService
    {
        HashSet<AulaDTO> GetDisponibilidadAula(ReservaDTO reservaDTO);
    }
}
