namespace Services.UserService
{
    public class UsuarioDTO
    {
        public int id   {  get; set; }
        public string nombre {  get; set; }
        public string contraseña { get; set; }
        public bool estado { get; set; }
    }
}