using AutoMapper;
using NumberDecompose.CrossCutting.DTO.Number;
using NumberDecompose.Domain;

namespace NumberDecompose.Mapper
{
    public class MapperDtoToEntity : Profile
    {
        public MapperDtoToEntity()
        {
            CreateMap<NumberInsertDTO, Number>();
            CreateMap<NumberDTO, Number>();
        }
    }
}