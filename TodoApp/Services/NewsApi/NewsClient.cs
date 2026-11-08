
using System.Collections;

namespace TodoApp.Services.NewsApi
{
    public class NewsClient : INewsClient
    {
        private readonly HttpClient _http;

        public NewsClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<NewsArticleDto?> GetArticleAsync(int id, CancellationToken cancellationToken = default)
        { // tek makale dönen metot bu
            return await _http.GetFromJsonAsync<NewsArticleDto>($"api/NewsArticles/{id}", cancellationToken);

        }

        public async Task<IEnumerable<NewsArticleDto>> GetArticlesAsync(CancellationToken cancellationToken = default)
        { //toplu makale dönen metot bu
            var result = await _http.GetFromJsonAsync<IEnumerable<NewsArticleDto>>("api/NewsArticles" , cancellationToken);
            return result ?? Enumerable.Empty<NewsArticleDto>(); // eğer result ifadesi null ise listeden boş bir liste oluştur onu dönder
        }
    }
}
