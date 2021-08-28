using NumberDecompose.Business.Interface.Base;
using NumberDecompose.CrossCutting.DTO.Number;
using NumberDecompose.Domain;
using System.Collections.Generic;

namespace NumberDecompose.Business.Interface
{
    public interface INumberService : IServiceBase<Number>
    {
        NumberDTO Decompose(int value);

        List<int> GetDividers(int value);

        List<int> GetPrimes(List<int> values);

        bool IsPrime(int value);
    }
}