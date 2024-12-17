namespace Model.Exceptions
{
    public class SuperposicionDeAulasException : Exception
    {
        public List<List<SuperposicionInfoDTO>> superposiciones { get; set; }
        public SuperposicionDeAulasException(List<List<SuperposicionInfoDTO>> superposiciones) : base("No se puede superponer una reserva con otra")
        {
            this.superposiciones = superposiciones;
        }
    }
}
