﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal
{
    public interface IRepositoryFactory
    {
        IGenericRepository<TEntity, tKey> CreateRepository<TEntity, tKey>();
    }
}
