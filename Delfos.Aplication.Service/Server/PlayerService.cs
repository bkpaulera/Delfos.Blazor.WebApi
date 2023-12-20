using Delfos.Aplication.Service.Request;
using Delfos.Aplication.Service.Response;
using Delfos.Domain.Abstractions.Repository;
using Delfos.Domain.Abstractions.Service;
using Delfos.Domain.Entities;
using Delfos.Domain.Models;

namespace Delfos.Aplication.Service.Server
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository repository)
        {
            _playerRepository = repository;
        }

        public async Task<PlayerResponse> GetAll()
        {
            try
            {
                List<PlayerDto> playersRepo = await _playerRepository.GetAll();

                if (playersRepo != null)
                {
                    List<PlayerDto> playerEntitiesList = playersRepo.Select(playerRepo => new PlayerDto
                    {
                        Id = playerRepo.Id,
                        Name = playerRepo.Name
                    }).ToList();

                    return new PlayerResponse(playersRepo, "200");
                }
                else
                {
                    return new PlayerResponse(null, "Failed to getAll player");
                }
            }
            catch (Exception ex)
            {
                var response = new PlayerResponse(null, ex.ToString());
                return response;
            }
        }


        public async Task<PlayerResponse> GetById(int id)
        {
            try
            {
                PlayerDto players = await _playerRepository.GetById(id);

                if (players != null)
                {
                    return new PlayerResponse(new List<PlayerDto> { players }, "200");

                }
                else
                {
                    return new PlayerResponse(null, "Player not found");
                }

            }
            catch (Exception ex)
            {
                return new PlayerResponse(null, ex.ToString());
            }

        }

        public async Task<PlayerResponse> Create(PlayerRequest entity)
        {
            try
            {
                if (entity?.PlayerEntitie?.Count > 0)
                {
                    PlayerDto model = new PlayerDto
                    {
                        Name = entity.PlayerEntitie[0].Name
                    };

                    var player = await _playerRepository.Create(model);

                    if (player != null)
                    {
                        PlayerDto playerEntities = new PlayerDto
                        {
                            Id = player.Id,
                            Name = player.Name
                        };

                        return new PlayerResponse(new List<PlayerDto> { playerEntities }, "200");
                    }
                    else
                    {
                        return new PlayerResponse(null, "Failed to create player");
                    }
                }
                else
                {
                    return new PlayerResponse(null, "Player not found");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // logger.LogError(ex, "An error occurred while processing the player creation.");

                return new PlayerResponse(null, $"An error occurred while processing the player creation: {ex.Message}");
            }
        }

        public async Task<PlayerResponse> Delete(PlayerRequest entity)
        {
            try
            {
                if (entity?.PlayerEntitie?.Count > 0)
                {
                    PlayerDto model = new PlayerDto
                    {
                        Id = entity.PlayerEntitie[0].Id,
                        Name = entity.PlayerEntitie[0].Name
                    };

                    var player = await _playerRepository.DeleteById(model);

                    if (player != null)
                    {

                        PlayerDto playerEntities = new PlayerDto
                        {
                            Id = player.Id,
                            Name = player.Name
                        };

                        return new PlayerResponse(new List<PlayerDto> { playerEntities }, "200");
                    }
                    else
                    {
                        return new PlayerResponse(null, "Failed to delete the player");
                    }
                }
                else
                {
                    return new PlayerResponse(null, "Player not found");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // logger.LogError(ex, "An error occurred while processing the player creation.");

                return new PlayerResponse(null, $"An error occurred while processing the player creation: {ex.Message}");
            }
        }

        public async Task<PlayerResponse> Update(PlayerRequest entity)
        {
            try
            {
                if (entity?.PlayerEntitie?.Count > 0)
                {
                    PlayerDto model = new PlayerDto
                    {
                        Id = entity.PlayerEntitie[0].Id,
                        Name = entity.PlayerEntitie[0].Name
                    };

                    var player = await _playerRepository.Update(model);

                    if (player != null)
                    {
                        PlayerDto playerEntities = new PlayerDto
                        {
                            Id = player.Id,
                            Name = player.Name
                        };

                        return new PlayerResponse(new List<PlayerDto> { playerEntities }, "200");
                    }
                    else
                    {
                        return new PlayerResponse(null, "Failed to create player");
                    }
                }
                else
                {
                    return new PlayerResponse(null, "Player not found");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // logger.LogError(ex, "An error occurred while processing the player creation.");

                return new PlayerResponse(null, $"An error occurred while processing the player: {ex.Message}");
            }
        }
    }
}
