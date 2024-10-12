using AutoMapper;
using Job_portal_backend_net8.Core.DTOs.Company;
using Job_portal_backend_net8.Core.Entities;

namespace Job_portal_backend_net8.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile() {

            CreateMap<CompanyCreateDTO,Company>();
        }
    }
}
