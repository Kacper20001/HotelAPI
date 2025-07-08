using Microsoft.Extensions.Logging;
using ReservationService.Application.Interfaces;
using Shared.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace ReservationService.Infrastructure.HttpClients
{
    public class DiscountApiClient : IDiscountApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DiscountApiClient> _logger;

        public DiscountApiClient(HttpClient httpClient, ILogger<DiscountApiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<DiscountDto?> GetByIdAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Discounts/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Discount API returned non-success status: {StatusCode}", response.StatusCode);
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DiscountDto>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error contacting DiscountService");
                return null;
            }
        }
    }
}
