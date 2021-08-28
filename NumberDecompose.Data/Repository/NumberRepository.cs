using NumberDecompose.Data.Base;
using NumberDecompose.Data.Context;
using NumberDecompose.Data.Interface;
using NumberDecompose.Domain;

namespace NumberDecompose.Data.Repository
{
    public class NumberRepository : RepositoryBase<Number>, INumberRepository
    {
        public NumberRepository(DataContext context) : base(context)
        {
        }
    }
}