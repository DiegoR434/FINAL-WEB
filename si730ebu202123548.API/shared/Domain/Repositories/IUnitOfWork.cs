namespace si730ebu202123548.API.shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}