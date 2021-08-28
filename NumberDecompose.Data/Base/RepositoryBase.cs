﻿using NumberDecompose.Data.Context;
using NumberDecompose.Data.Interface.Base;
using NumberDecompose.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberDecompose.Data.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly DataContext _context;

        public RepositoryBase(DataContext context)
        {
            _context = context;
        }

        public DataContext GetContext()
        {
            return new DataContext();
        }

        public virtual Guid Create(T dto)
        {
            dto.Date = DateTime.Now;
            dto.Active = true;
            _context.Set<T>().Add(dto);
            _context.SaveChanges();

            return dto.Id;
        }

        public virtual T Update(T dto)
        {
            var currentValue = Find(dto.Id);
            SetValue(currentValue, dto);
            return currentValue;
        }

        public virtual void Remove(Guid id)
        {
            var obj = Find(id);
            obj.Active = false;
            SetValue(obj);
            _context.SaveChanges();
        }

        public virtual T Find(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(f => f.Id.Equals(id) && f.Active);
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().Where(w => w.Active).ToList();
        }

        protected virtual void SetValue(T dto)
        {
            var newValue = _context.Set<T>().Find(dto.Id);
            _context.Entry(dto).CurrentValues.SetValues(newValue);
            if (dto?.Version != newValue.Version)
                throw new Exception("Registro desatualizado, tente novamente");

            dto.Version++;
            dto.Date = DateTime.Now;
            _context.SaveChanges();
        }

        protected virtual void SetValue(T dto, T newValue)
        {
            _context.Entry(dto).CurrentValues.SetValues(newValue);

            if (dto?.Version != newValue.Version)
                throw new Exception("Registro desatualizado, tente novamente");

            dto.Version++;
            dto.Date = DateTime.Now;
            _context.SaveChanges();
        }
    }
}