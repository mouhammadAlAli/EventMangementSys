namespace Domain.Repositries
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
    }
}
