using System.Text.Json;
using AutoMapper;
using CelestialConvoyCentral.Fleet.Domain;
using UtilityServices.ProviderAPI;

namespace CelestialConvoyCentral.Fleet.Client.Client;

public class StarshipManufacturerClient : BaseClient,  IStarshipManufacturerClient
{
    private readonly string APIURL = "https://swapi.dev/api/starships/";

    private readonly Mapper _mapper;
    public StarshipManufacturerClient(IHttpClientFactory httpClientFactory, Mapper mapper)
        : base(nameof(StarshipManufacturerClient), httpClientFactory)
    {
        _mapper = mapper;
    }

    public async Task<StarshipModel> GetModelByClientID(int id)
    {
        var response = await GetAsync($"{APIURL}/{id}");

        if(response.IsSuccessStatusCode is false) return null;
        
        var starshipModelClient =  HandleResponse<StarshipModelClientResponse>(response.Content);
        return _mapper.Map<StarshipModel>(starshipModelClient);
    }
}
