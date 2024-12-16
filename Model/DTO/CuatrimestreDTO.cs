namespace Model.DTO;

public class CuatrimestreDTO
{
    public int IdCuatrimestre { get; set; }
    public int numeroCuatrimestre { get; set; }
    public DateTime fechaInicio { get; set; }
    public DateTime fechaFin { get; set; }
    public AnioLectivoDTO anioLectivo { get; set; }
    
    public CuatrimestreDTO() { }
}