using Model.DTO;
using Model.Entity;

namespace Services.UserService
{
    public interface IUserService
    {
        BedelDTO registrarBedel(BedelDTO bedel);
        BedelDTO buscarBedel(int id);
        Bedel crearNuevoBedel(BedelDTO bedelDTO);

    }
}
