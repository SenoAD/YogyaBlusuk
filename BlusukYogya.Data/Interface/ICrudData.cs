﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlusukYogya.Data.Interface
{
    public interface ICrudData<T>
    {
        Task Create(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
        Task Delete(int id);
    }

}
