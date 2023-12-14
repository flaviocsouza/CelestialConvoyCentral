using AutoMapper;
using CelestialConvoyCentral.Fleet.Domain;

namespace CelestialConvoyCentral.Fleet.Client;

public class StarshipModelProfile : Profile
{
    public StarshipModelProfile()
    {
        CreateMap<StarshipModelClientResponse, StarshipModel>()
            .ReverseMap();
        
    }

}
