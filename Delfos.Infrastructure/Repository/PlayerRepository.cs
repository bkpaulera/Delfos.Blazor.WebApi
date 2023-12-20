using Delfos.Domain.Abstractions.Repository;
using Delfos.Domain.Entities;
using Delfos.Domain.Models;
using Delfos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Delfos.Infrastructure.Repository
{
    //Repositorio especializado
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DataDbContext _context;

        public PlayerRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<PlayerDto> GetById(int id)
        {
            PlayerDto dto = await _context.Players
                .Where(u => u.Id == id)
                .Select(u => new PlayerDto(u.Id, u.Name))
                .FirstOrDefaultAsync();

            return dto;
        }

        public async Task<List<PlayerDto>> GetAll()
        {

            List<PlayerDto> dtos = await _context.Players
              .Select(u => new PlayerDto(u.Id, u.Name))
              .ToListAsync();

            return dtos;
        }

        public async Task<PlayerDto> Create(PlayerDto entity)
        {
            try
            {
                PlayersModel newPlayer = PlayersModel.CreateNewPlayer(entity.Id, entity.Name);

                // Adicionar a nova entidade ao contexto usando AddAsync
                var addedPlayer = await _context.Players.AddAsync(newPlayer);

                await _context.SaveChangesAsync();

                var addedDto = new PlayerDto
                {
                    Id = addedPlayer.Entity.Id,
                    Name = addedPlayer.Entity.Name
                };

                // Return the created entity
                return addedDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<PlayerDto> DeleteById(PlayerDto entity)
        {
            try
            {
                PlayersModel playerToRemove = await _context.Players.FindAsync(entity.Id);

                if (playerToRemove != null)
                {
                    var removePlayer = _context.Players.Remove(playerToRemove);
                    await _context.SaveChangesAsync();

                }

                return new PlayerDto(playerToRemove.Id, playerToRemove.Name);
                // Return the created entity

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PlayerDto> Update(PlayerDto entity)
        {
            try
            {
                PlayersModel playerToUpdate = await _context.Players.FindAsync(entity.Id);

                if (playerToUpdate != null)
                {
                    playerToUpdate.Name = entity.Name;

                    _context.Players.Update(playerToUpdate);
                    await _context.SaveChangesAsync();

                    return new PlayerDto(playerToUpdate.Id, playerToUpdate.Name);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
