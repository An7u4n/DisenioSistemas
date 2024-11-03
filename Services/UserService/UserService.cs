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

        public List<BedelDTO> buscarBedel(string apellido, Turno? turno)
        {
            var bedeles = _userDAO.buscarBedeles(apellido, turno);
            var bedelDTOs = new List<BedelDTO>();
            foreach (var bedel in bedeles)
            {
                bedelDTOs.Add(new BedelDTO(
                    idBedel: bedel.getId(),
                    apellido: bedel.getApellido(),
                    nombre: bedel.getNombre(),
                    turno: bedel.getTurno(),
                    usuario: bedel.getUsuario()
                ));
            }
            return bedelDTOs;

        }
        public Bedel crearNuevoBedel(BedelDTO bedelDTO)
        {
            if (string.IsNullOrEmpty(bedelDTO.Apellido) || string.IsNullOrEmpty(bedelDTO.Nombre))
            {
                throw new ArgumentException("El nombre y apellido del Bedel son obligatorios.");
            }

            if (!Enum.IsDefined(typeof(Turno), bedelDTO.Turno))
            {
                throw new ArgumentException("Turno invalido");
            }

            var bedel = new Bedel(
                usuario: bedelDTO.Usuario,
                apellido: bedelDTO.Apellido,
                nombre: bedelDTO.Nombre,
                turno: bedelDTO.Turno
            );

            return bedel;
        }

        public BedelDTO registrarBedel(BedelDTO bedelDTO)
        {

            if (bedelDTO == null)
            {
                throw new ArgumentNullException(nameof(bedelDTO), "El Bedel no puede ser nulo.");
            }

            try
            {
                var bedel = _userDAO.obtenerUsuario(bedelDTO.Usuario);
            }
            catch (Exception e) when (e.Message == "No existe el bedel")
            {
                var bedel = crearNuevoBedel(bedelDTO);
                var nuevoBedel = _userDAO.guardarUsuarioBedel(bedel);
                bedelDTO.IdBedel = nuevoBedel.getId();
                return bedelDTO;
            }
            throw new ArgumentException("El usuario ya existe");
        }
        public BedelDTO actualizarEstado(Bedel bedel)
        {
            var bedelDTO = new BedelDTO(
                idBedel: bedel.getId(),
                apellido: bedel.getApellido(),
                nombre: bedel.getNombre(),
                turno: bedel.getTurno(),
                usuario: bedel.getUsuario()
            );
            return bedelDTO;
        }

        public BedelDTO eliminarBedelLogico(string usuarioBedel)
        {
            try
            {
                Bedel bedel = _userDAO.obtenerUsuario(usuarioBedel);
                bedel = _userDAO.marcarEliminado(bedel);
                BedelDTO bedelDTO = actualizarEstado(bedel);
                return bedelDTO;
            }
            catch (Exception e) when (e.Message == "No existe el bedel")
            {
                throw new ArgumentException("No existe el bedel");
            }
        }
    }
}
