using Model.DTO;
using Model.Entity;
using Services.UserService;
using Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AuthService
{
    public class AuthService : IAuthService
    {
        
        private IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }
        
        public LoginDTO login(LoginDTO loginDTO)
        {
          var usuario = _userService.obtenerUsuario(loginDTO.name);

          if(!PasswordHasher.VerifyPassword(loginDTO.password,usuario.getContrasena())) {
            throw new UnauthorizedAccessException("La contraseña es incorrecta");
          }

            loginDTO.id = usuario.getId();
            loginDTO.isAdmin = usuario is Administrador;

            return loginDTO;  

        }


    }
}
