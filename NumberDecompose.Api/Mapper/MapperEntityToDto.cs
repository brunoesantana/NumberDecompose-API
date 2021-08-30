using AutoMapper;
using NumberDecompose.Business.Interface;
using NumberDecompose.Business.Service;
using NumberDecompose.CrossCutting.DTO.Number;
using NumberDecompose.Data.Context;
using NumberDecompose.Data.Interface;
using NumberDecompose.Data.Repository;
using NumberDecompose.Domain;
using System.Linq;

namespace NumberDecompose.Mapper
{
    public class MapperEntityToDto : Profile
    {
        private readonly INumberService _service;
        private readonly INumberRepository _repository;
        private readonly DataContext _dataContext;

        public MapperEntityToDto()
        {
            _dataContext = new DataContext();
            _repository = new NumberRepository(_dataContext);
            _service = new NumberService(_repository);

            CreateMap<Number, NumberInsertDTO>();
            CreateMap<Number, NumberResumedDTO>();

            CreateMap<Number, NumberDTO>()
            .AfterMap((src, dest) =>
            {
                dest.Divisors = _service.GetDividers(src.Value);
                dest.PrimeDivisors = _service.GetPrimes(dest.Divisors.ToList());
            });
        }
    }
}