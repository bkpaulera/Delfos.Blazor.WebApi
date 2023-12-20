using Delfos.Aplication.Service.Request;
using Delfos.Aplication.Service.Response;
using Delfos.Domain.Abstractions.Service;
using Delfos.Domain.Entities;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Delfos.Aplication.Service.Client
{

    namespace Delfos.Aplication.Service.Client
    {
        public class PlayerWebClient : IPlayerService
        {
            private readonly HttpClient _clientFactory;

            public PlayerWebClient(HttpClient clientFactory)
            {
                _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

            }

            public async Task<PlayerResponse> GetAll()
            {
                try
                {

                    var response = await _clientFactory.GetAsync("https://localhost:7195/api/Player/GetAll");

                    if (response.IsSuccessStatusCode)
                    {
                        var playersStream = await response.Content.ReadAsStringAsync();

                        var playersResponse = JsonSerializer.Deserialize<PlayerResponse>(playersStream);

                        if (playersResponse != null && playersResponse.PlayerEntitie != null)
                        {
                            return playersResponse;
                        }
                        else
                        {
                            // Lógica para tratar uma resposta mal formada ou sem dados
                            return new PlayerResponse(null, "500");
                        }
                    }
                    else
                    {
                        // Adicione logs para entender melhor o motivo da falha
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Failed to get players. Status code: {response.StatusCode}. Error: {errorMessage}");
                        return new PlayerResponse(null, ((int)response.StatusCode).ToString());
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.WriteLine(ex.Message);
                    return new PlayerResponse(null, "500");
                }
            }

            public Task<PlayerResponse> GetById(int id)
            {
                throw new NotImplementedException();
            }
            public Task<PlayerResponse> Create(PlayerRequest entity)
            {
                throw new NotImplementedException();
            }

            public Task<PlayerResponse> Delete(PlayerRequest entity)
            {
                throw new NotImplementedException();
            }
            public Task<PlayerResponse> Update(PlayerRequest entity)
            {
                throw new NotImplementedException();
            }

        }
    }


}
