using AddressBooking.Core;
using AutoMapper;

namespace AddressBooking.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactDto, Contact>().ReverseMap();
            CreateMap<Contact, CsvContactsDto>().ReverseMap();
        }
    }
}
