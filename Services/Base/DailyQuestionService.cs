using Entities.Models.Context;
using Services.Exceptions;

namespace Services.Base;

public class DailyQuestionService
{
    protected readonly DailyQuestionContext _context;

    public DailyQuestionService(DailyQuestionContext context)
    {
        _context = context;
    }
    
    public async Task<T> FindEntityById<T>(Guid id) where T : class
    {
        T? entity = await _context.Set<T>().FindAsync(id);

        if (entity is null)
        {
            throw new IdNotFoundException($"The {typeof(T).Name} with id {id} was not found.");
        }

        return entity;
    }
}