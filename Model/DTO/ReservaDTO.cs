using Model.Enums;
namespace Model.DTO
{
    public abstract class ReservaDTO
    {
        public int idReserva { get; set; }
        public string profesor { get; set; }
        public string nombreCatedra { get; set; }
        public string correoElectronico { get; set; }

        public int cantidadAlumnos { get; set; }
        public int idBedel { get; set; }
        public int idCuatrimestre { get; set; }
        public TipoAula tipoAula { get; set; }


        public ReservaDTO() { }


        public ReservaDTO(int idReserva, string profesor, string nombreCatedra, string correoElectronico, int cantidad_alumnos, int idBedel)
        {
            this.idReserva = idReserva;
            this.profesor = profesor;
            this.nombreCatedra = nombreCatedra;
            this.correoElectronico = correoElectronico;
            this.cantidadAlumnos = cantidad_alumnos;
            this.idBedel = idBedel;
        }
    }
}
