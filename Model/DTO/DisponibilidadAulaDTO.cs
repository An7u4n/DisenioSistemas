using Model.Enums;

namespace Model.DTO;

public class DisponibilidadAulaDTO
{
    public DateTime? Dia { get; set; } // Fecha específica del día
    public List<AulaDTO> AulasDisponibles { get; set; } // Aulas sin superposición
    public DiaSemana? DiaSemana { get; set; } // Usado para reservas periódicas
    public List<SuperposicionInfoDTO> SuperposicionesMinimas { get; set; } // Aulas con la menor superposición
}
