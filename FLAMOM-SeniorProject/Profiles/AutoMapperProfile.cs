using AutoMapper;
using FLAMOM_SeniorProject.ViewModel;

namespace FLAMOM_SeniorProject.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VisitInformationVM, DentalHealthVM>();
            CreateMap<DentalHealthVM, AboutYouVM>();
            CreateMap<AboutYouVM, YourHouseholdVM>();
        }
       
    }
}
