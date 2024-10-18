using Model.DTO;

namespace Services.UserService
{
    public interface IUserService
    {
        BedelDTO registrarBedel(BedelDTO bedel);
        BedelDTO buscarBedel(int id);


    }
}
