using System.Text.Json.Serialization;

namespace Delfos.Domain.Entities
{
    public record PlayerDto
    {
        public PlayerDto()
        {

        }
        public PlayerDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }

        public override string ToString() => $" Id : {Id} |  Name : {Name}";
    }
}