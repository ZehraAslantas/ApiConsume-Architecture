using System.Net;
using ContactApp.Contracts.DTOs;

namespace ContactApp.Services;

public class NewsService : INewsService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<NewsService> _logger;

    public NewsService(HttpClient httpClient, ILogger<NewsService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IReadOnlyList<NewsArticleDto>> GetAllAsync(CancellationToken cancellationToken = default)

    {
        try
        {
            var list = await _httpClient.GetFromJsonAsync<List<NewsArticleDto>>("api/NewsArticles" , cancellationToken);
            // appsettingsjson.developmenttaki http ye ek olarak buradaki "api/NewsArticles" eklenerek o adrese istek gider
        return list ?? new List<NewsArticleDto>(); // ?? ifadesi list null ise çalışır
        }
        catch (Exception ex) {
            _logger.LogError(ex, "API isteği başarısız oldu");
            return Array.Empty<NewsArticleDto>(); // boş liste döner
        }
    }

    public async Task<NewsArticleDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient
                .GetAsync($"api/NewsArticles/{id}", cancellationToken);

            if(response.StatusCode == HttpStatusCode.NotFound) //404
            {
                return null;
            }
            response.EnsureSuccessStatusCode(); //200 kodu
            return await response.Content.ReadFromJsonAsync<NewsArticleDto>(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Id: {id} ilgili haber okunamadı!");
            return null;
        
        }
    }
}
