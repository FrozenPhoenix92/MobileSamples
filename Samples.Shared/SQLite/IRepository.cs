﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Shared.SQLite
{
    public interface IRepository<T> where T :class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Create(T item);
        int Update(T item);
        int Delete(int id);
    }
}
