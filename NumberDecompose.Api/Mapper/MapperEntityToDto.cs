using AutoMapper;
using NumberDecompose.CrossCutting.DTO.Number;
using NumberDecompose.Domain;

namespace NumberDecompose.Mapper
{
    public class MapperEntityToDto : Profile
    {
        public MapperEntityToDto()
        {
            CreateMap<Number, NumberInsertDTO>();
            CreateMap<Number, NumberDTO>();
        }
    }
}