using ContactApp.Contracts.DTOs;

namespace ContactApp.Services;

public interface INewsService
{
    Task<IReadOnlyList<NewsArticleDto>> GetAllAsync(CancellationToken cancellation = default);
    Task<NewsArticleDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}
