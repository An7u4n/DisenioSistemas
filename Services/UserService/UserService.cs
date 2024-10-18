using Model.DTO;
using Model.Entity;
using Data.DAO;
using DisenioSistemas.Model.Enums;

namespace Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserDAO _userDAO;

        public UserService(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public BedelDTO buscarBedel(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del Bedel debe ser un número positivo.", nameof(id));
            }

            var bedel = _userDAO.ObtenerPorId(id);

            if (bedel == null)
            {
                throw new KeyNotFoundException($"No se encontró un Bedel con el ID {id}.");
            }

            return new BedelDTO
            {
                IdBedel = bedel.getId(),
                Apellido = bedel.getApellido(),
                Nombre = bedel.getNombre(),
                Turno = bedel.getTurno()
            };
        }

        public BedelDTO registrarBedel(BedelDTO bedelDTO)
        {
            if (bedelDTO == null)
            {
                throw new ArgumentNullException(nameof(bedelDTO), "El Bedel no puede ser nulo.");
            }

            if (string.IsNullOrEmpty(bedelDTO.Apellido) || string.IsNullOrEmpty(bedelDTO.Nombre))
            {
                throw new ArgumentException("El nombre y apellido del Bedel son obligatorios.");
            }

            if (!Enum.IsDefined(typeof(Turno), bedelDTO.Turno))
            {
                throw new ArgumentException("Turno invalido");
            }

            var bedel = new Bedel(
                usuario: bedelDTO.Nombre,
                apellido: bedelDTO.Apellido,
                nombre: bedelDTO.Nombre,
                turno: bedelDTO.Turno
            );

            var nuevoBedel = _userDAO.AddBedel(bedel);

            bedelDTO.IdBedel = nuevoBedel.getId();

            return bedelDTO;
        }

    }
}
