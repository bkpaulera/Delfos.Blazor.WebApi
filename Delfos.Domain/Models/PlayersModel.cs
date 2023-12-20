namespace Delfos.Domain.Models
{
    //Modelo de objeto
    public class PlayersModel
    {
        public PlayersModel() { }
        
        public int Id { get; set; }
        public required string Name { get; set; }

        public static PlayersModel CreateNewPlayer(int id, string name)
        {
            // Lógica de validação e regras de negócios
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("O nome do jogador não pode estar vazio.");
            }

            // Criação da instância
            var player = new PlayersModel
            {
                Id = id,
                Name = name
                // Outras propriedades...
            };

            return player;
        }

    }
}
