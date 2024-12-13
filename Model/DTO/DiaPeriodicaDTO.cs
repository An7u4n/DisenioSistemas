using Model.Enums;
namespace Model.DTO
{
    public class DiaPeriodicaDTO
    {
        public int idDia { get; set; }
        public int? numeroAula { get; set; }
        public string horaInicio { get; set; }
        public int duracionMinutos { get; set; }
        public DiaSemana diaSemana { get; set; }
    }

    public class DiaEsporadicaDTO
    {
        public int idDia { get; set; }
        public int? numeroAula { get; set; }
        public string horaInicio { get; set; }
        public int duracionMinutos { get; set; }
        public DateTime fecha { get; set; }
    }
}
