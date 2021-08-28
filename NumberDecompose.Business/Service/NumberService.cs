using NumberDecompose.Business.Base;
using NumberDecompose.Business.Interface;
using NumberDecompose.CrossCutting.DTO.Number;
using NumberDecompose.CrossCutting.Exceptions;
using NumberDecompose.CrossCutting.Helper;
using NumberDecompose.Data.Interface;
using NumberDecompose.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberDecompose.Business.Service
{
    public class NumberService : ServiceBase<Number>, INumberService
    {
        public NumberService(INumberRepository repository) : base(repository)
        {
        }

        public NumberDTO Decompose(int value)
        {
            var divisors = GetDividers(value);
            var primes = GetPrimes(divisors);

            return new NumberDTO
            {
                Id = Guid.NewGuid(),
                Value = value,
                Divisors = divisors,
                PrimeDivisors = primes,
                Date = DateTime.Now,
            };
        }

        public List<int> GetDividers(int value)
        {
            if (value <= ConstantHelper.ZERO)
                throw new EntityValidationException("Informe um valor inteiro, positivo e maior que zero.");

            var divisors = new List<int> { ConstantHelper.ONE };

            for (var i = ConstantHelper.TWO; i <= value; i++)
            {
                if (value % i == ConstantHelper.ZERO)
                    divisors.Add(i);
            }

            return divisors;
        }

        public List<int> GetPrimes(List<int> values)
        {
            if (!values.Any())
                return new List<int>();

            var primes = new List<int>();

            foreach (var item in values)
            {
                if (IsPrime(item))
                    primes.Add(item);
            }

            return primes;
        }

        public bool IsPrime(int value)
        {
            if (value <= ConstantHelper.ZERO)
                return false;

            for (var i = ConstantHelper.TWO; i <= (int)Math.Sqrt(value); i++)
            {
                if (value % i == ConstantHelper.ZERO)
                    return false;
            }

            return true;
        }
    }
}