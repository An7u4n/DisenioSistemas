using Model.DTO;
using Model.Entity;
using Data.DAO;
using DisenioSistemas.Model.Enums;
using DisenioSistemas.Model.Abstract;
using Data.Utilities;

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
            try
            {
                var bedeles = _userDAO.buscarBedeles(apellido, turno);
                var bedelDTOs = new List<BedelDTO>();
                foreach (var bedel in bedeles)
                {
                    bedelDTOs.Add(new BedelDTO(
                        idBedel: bedel.getId(),
                        contrasena: bedel.getContrasena(),
                        apellido: bedel.getApellido(),
                        nombre: bedel.getNombre(),
                        turno: bedel.getTurno(),
                        usuario: bedel.getUsuario()
                    ));
                }
                return bedelDTOs;
            }
            catch(NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }

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
                contrasena: bedelDTO.Contrasena,
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
                var bedel = _userDAO.obtenerUsuarioBedel(bedelDTO.Usuario);
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
                contrasena: bedel.getContrasena(),
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
                Bedel bedel = _userDAO.obtenerUsuarioBedel(usuarioBedel);
                bedel = _userDAO.marcarEliminado(bedel);
                BedelDTO bedelDTO = actualizarEstado(bedel);
                return bedelDTO;
            }
            catch (Exception e) when (e.Message == "No existe el bedel")
            {
                throw new ArgumentException("No existe el bedel");
            }
        }

        public BedelDTO actualizarBedel(BedelDTO bedelDTO)
        {
            try
            {
                var bedelExistente = _userDAO.obtenerUsuarioBedel(bedelDTO.Usuario);

                if (bedelExistente == null)
                {
                    throw new ArgumentException("No existe el bedel");
                }

                var bedelActualizado = modificarBedel(bedelDTO, bedelExistente);

                var updatedBedel = _userDAO.actualizarBedel(bedelActualizado);

                return new BedelDTO(
                    idBedel: updatedBedel.getId(),
                    contrasena: updatedBedel.getContrasena(),
                    apellido: updatedBedel.getApellido(),
                    nombre: updatedBedel.getNombre(),
                    turno: updatedBedel.getTurno(),
                    usuario: updatedBedel.getUsuario()
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el Bedel: " + ex.Message);
            }
        }
        public Bedel modificarBedel(BedelDTO bedelNuevo, Bedel bedelAnterior)
        {
            try
            {
                if (bedelNuevo == null || bedelAnterior == null)
                {
                    throw new ArgumentNullException("Los datos del Bedel no pueden ser nulos.");
                }
                if (bedelNuevo.Apellido != bedelAnterior.getApellido())
                {
                    bedelAnterior.setApellido(bedelNuevo.Apellido);
                }
                if (bedelNuevo.Nombre != bedelAnterior.getNombre())
                {
                    bedelAnterior.setNombre(bedelNuevo.Nombre);
                }
                if (bedelNuevo.Turno != bedelAnterior.getTurno())
                {
                    bedelAnterior.setTurno(bedelNuevo.Turno);
                }
                if (bedelNuevo.Contrasena != bedelAnterior.getContrasena())
                {
                    bedelAnterior.setContrasena(bedelNuevo.Contrasena);
                }
                return bedelAnterior;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el Bedel: " + ex.Message);
            }
        }
    }
}
