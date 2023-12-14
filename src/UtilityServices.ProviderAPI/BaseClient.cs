namespace UtilityServices.ProviderAPI;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.XPath;

public abstract class BaseClient
{
    protected HttpClient _client;
    public BaseClient(string clientName, IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient(clientName);
    }
    
    protected async Task<HttpResponseMessage> SendAsync<TRequest>(TRequest request, string url, HttpMethod method)
        where TRequest : class
    {
        using var requestMessage = new HttpRequestMessage(method, url);

        var jsonString = JsonSerializer.Serialize(request);
        using var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
        requestMessage.Content = stringContent;

        return await _client.SendAsync(requestMessage);
    }

    protected async Task<HttpResponseMessage> PostAsync<TRequest>(TRequest request, string url)
        where TRequest : class
        => await SendAsync(request, url, HttpMethod.Post);

        
    protected async Task<HttpResponseMessage> GetAsync(string url)
    {
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        return await _client.SendAsync(requestMessage);
    }

    protected TResponse HandleResponse<TResponse>(HttpContent content)
    {
        return JsonSerializer.Deserialize<TResponse>(content.ReadAsStream());
    }
}
