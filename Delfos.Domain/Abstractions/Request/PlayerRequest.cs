using Delfos.Domain.Entities;

namespace Delfos.Aplication.Service.Request
{
    public class PlayerRequest(List<PlayerDto>? playerEntitie)
    {
        public List<PlayerDto> PlayerEntitie { get; set; } = playerEntitie;
    }
}
