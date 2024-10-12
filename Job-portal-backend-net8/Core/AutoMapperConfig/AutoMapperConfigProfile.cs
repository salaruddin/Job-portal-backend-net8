using AutoMapper;
using Job_portal_backend_net8.Core.DTOs.Company;
using Job_portal_backend_net8.Core.DTOs.Job;
using Job_portal_backend_net8.Core.Entities;

namespace Job_portal_backend_net8.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile() {

            //comapny
            CreateMap<CompanyCreateDTO,Company>();
            CreateMap<Company, CompanyGetDTO>();

            //job
            CreateMap<JobCreateDTO,Job>();
            CreateMap<Job, JobGetDTO>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(src => src.Company.Name));

        }
    }
}
