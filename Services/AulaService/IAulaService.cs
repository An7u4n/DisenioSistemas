using Model.DTO;

using Model.Abstract;
using Model.DTO;
using Model.Entity;

namespace Services.AulaService
{
    public interface IAulaService
    {
        HashSet<AulaDTO> GetDisponibilidadAula(ReservaDTO reservaDTO);
        
    }
}
