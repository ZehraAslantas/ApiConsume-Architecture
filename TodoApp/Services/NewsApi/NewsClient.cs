using System.Net;

namespace TodoApp.Services.NewsApi
{
    public class NewsClient : INewsClient
    {
        private readonly HttpClient _http;
        private readonly ILogger<NewsClient> _logger;

        public NewsClient(HttpClient http, ILogger<NewsClient> logger)
        {
            _http = http;
            _logger = logger;
        }

        public async Task<NewsArticleDto?> GetArticleAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _http.GetAsync($"api/NewsArticles/{id}", cancellationToken);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<NewsArticleDto>(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Id: {Id} olan haber alınamadı.", id);
                return null;
            }
        }

        public async Task<IEnumerable<NewsArticleDto>> GetArticlesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _http.GetFromJsonAsync<IEnumerable<NewsArticleDto>>("api/NewsArticles", cancellationToken);
                return result ?? Enumerable.Empty<NewsArticleDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Haberler alınamadı.");
                return Enumerable.Empty<NewsArticleDto>();
            }
        }
    }
}