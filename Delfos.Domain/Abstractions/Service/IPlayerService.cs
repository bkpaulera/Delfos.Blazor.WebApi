using Delfos.Aplication.Service.Request;
using Delfos.Aplication.Service.Response;


namespace Delfos.Domain.Abstractions.Service
{
    public interface IPlayerService
    {
        public Task<PlayerResponse> GetAll();
        public Task<PlayerResponse> GetById(int id);
        public Task<PlayerResponse> Create(PlayerRequest entity);
        public Task<PlayerResponse> Update(PlayerRequest entity);
        public Task<PlayerResponse> Delete(PlayerRequest entity);
    }
}
