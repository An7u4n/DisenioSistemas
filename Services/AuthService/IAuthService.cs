﻿using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AuthService
{
    public interface IAuthService
    {
        public LoginDTO login(LoginDTO loginDTO);

    }
}
