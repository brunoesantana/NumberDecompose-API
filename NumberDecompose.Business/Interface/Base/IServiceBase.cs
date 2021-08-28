using System;
using System.Collections.Generic;

namespace NumberDecompose.Business.Interface.Base
{
    public interface IServiceBase<T> where T : class
    {
        Guid Create(T dto);

        T Update(T dto);

        void Remove(Guid id);

        T Find(Guid id);

        List<T> GetAll();
    }
}