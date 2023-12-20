namespace Delfos.Domain.Abstractions.Service
{
    public interface IService<T>
    {
        public Task<T> GetById(int id);
        public Task<T> GetAll();
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<T> DeleteById(T entity);
    }
}
