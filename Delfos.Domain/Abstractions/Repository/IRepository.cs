namespace Delfos.Domain.Abstractions.Repository
{
    //Tipo Generico de Repositorio
    public interface IRepository<T>
    {
        public Task<T> GetById(int id);
        public Task<List<T>> GetAll();
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<T> DeleteById(T entity);
    }
}
