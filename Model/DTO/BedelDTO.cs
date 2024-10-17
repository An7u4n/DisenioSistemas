using DisenioSistemas.Model.Enums;


namespace Model.DTO
{
    public class BedelDTO
    {
        public int IdBedel { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public Turno Turno { get; set; }

        public BedelDTO() { }

        public BedelDTO(int idBedel, string apellido, string nombre, Turno turno)
        {
            IdBedel = idBedel;
            Apellido = apellido;
            Nombre = nombre;
            Turno = turno;
        }
    }
}
