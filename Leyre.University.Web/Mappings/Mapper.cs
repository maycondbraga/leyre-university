using AutoMapper;
using Leyre.University.Dto.Dtos;
using Leyre.University.Model.Entities;

namespace Leyre.University.Web.Mappings
{
    /// <summary>
    /// Mapper class for Dtos
    /// </summary>
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<StudentDto, StudentModel>();
            CreateMap<StudentModel, StudentDto>();
        }
    }
}
