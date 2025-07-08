using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ReservationService.Application.Interfaces;
using Shared.DTOs;


namespace ReservationService.Infrastructure.HttpClients
{
    public class CustomerApiClient : ICustomerApiClient
    {
        private readonly HttpClient _httpClient;

        public CustomerApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(Guid customerId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/customers/{customerId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CustomerDto>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CustomerApiClient] Błąd połączenia z CustomerService: {ex.Message}");
            }

            return null;
        }
    }
}
