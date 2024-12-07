
﻿using Data.Utilities;
using Microsoft.EntityFrameworkCore;
using Model.Abstract;
using Model.Entity;
using Model.Enums;

﻿using Microsoft.EntityFrameworkCore;
using Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.DAO
{
    public class AulaDAO
    {
        private readonly AppDbContext _dbContext;

        public AulaDAO(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public HashSet<Aula> getAulasByTipo<T>() where T : Aula
        { 
            var aulas = _dbContext.Aulas
                .Where(a => a is T)
                .ToHashSet();

            return aulas;
        }

       
    }
}
