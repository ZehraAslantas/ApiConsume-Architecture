using TodoApp.Services.NewsApi;

namespace TodoApp.Services
{
    public interface INewsClient
    {
        Task<IEnumerable<NewsArticleDto>> GetArticlesAsync(CancellationToken cancellationToken=default);
        Task<NewsArticleDto?> GetArticleAsync(int id,CancellationToken cancellationToken=default);
    
    }
}
