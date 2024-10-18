using DisenioSistemas.Model.Enums;
using System.ComponentModel.DataAnnotations;


namespace Model.DTO
{
    public class BedelDTO
    {
        public int IdBedel { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El turno es obligatorio.")]
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
