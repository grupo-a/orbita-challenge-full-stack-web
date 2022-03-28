using AutoMapper;
using backend.Data.Dtos;
using backend.Models;

namespace backend.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentDTO, Student>();
            CreateMap<UpdateStudentDTO, Student>();

        }
    }
}
