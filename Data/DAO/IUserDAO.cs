using DisenioSistemas.Model.Abstract;
using DisenioSistemas.Model.Enums;
using Model.Entity;

namespace Data.DAO
{
    public interface IUserDAO
    {
        Bedel actualizarBedel(Bedel bedel);
        List<Bedel> buscarBedeles(string apellido, Turno? turno);
        List<Administrador> GetAdministradores();
        List<Bedel> GetBedeles();
        Usuario guardarUsuarioAdmin(Administrador usuario);
        Bedel guardarUsuarioBedel(Bedel bedel);
        Bedel marcarEliminado(Bedel bedel);
        Usuario obtenerUsuario(string usuario);
        Bedel obtenerUsuarioBedel(string usuario);
    }
}