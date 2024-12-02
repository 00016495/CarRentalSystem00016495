using AutoMapper;
using CarRentalSystem00016495.Api.Domain.Entities;
using CarRentalSystem00016495.Api.Service.DTOs.Cars;
using CarRentalSystem00016495.Api.Service.DTOs.Rentals;

namespace CarRentalSystem00016495.Api.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Car
        CreateMap<Car,CarForUpdateDto>().ReverseMap();
        CreateMap<Car, CarForResultDto>().ReverseMap();
        CreateMap<Car, CarForCreationDto>().ReverseMap();

        // Rental
        CreateMap<Rental, RentalForUpdateDto>().ReverseMap();
        CreateMap<Rental, RentalForResultDto>().ReverseMap();
        CreateMap<Rental, RentalForCreationDto>().ReverseMap();
    }
}
