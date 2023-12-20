using Delfos.Domain.Entities;
using System.Text.Json.Serialization;

namespace Delfos.Aplication.Service.Response
{
    public class PlayerResponse(List<PlayerDto>? playerEntitie, string message)
    {
        [JsonPropertyName("Player")]
        public List<PlayerDto> PlayerEntitie { get; set; } = playerEntitie;
        [JsonPropertyName("Message")]
        public string Message { get; set; } = message;
        
    }
}
