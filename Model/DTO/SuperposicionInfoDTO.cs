using Model.DTO;

public class SuperposicionInfoDTO
{
    public AulaDTO Aula { get; set; }
    public ReservaDTO Reserva { get; set; }
    public TimeOnly HoraInicio { get; set; }
    public TimeOnly HoraFin { get; set; }
    public double HorasSuperpuestas { get; set; }
}