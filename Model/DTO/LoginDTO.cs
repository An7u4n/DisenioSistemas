﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class LoginDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }

        public bool isAdmin { get; set; }

    }
}
