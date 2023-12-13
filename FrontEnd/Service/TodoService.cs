using Core.Dto;

namespace FrontEnd.Service
{
    public class TodoService
    {
        private readonly HttpClient _httpClient;
        private readonly string url = "http://localhost:5203/api/Todo";

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TodoDto?> Create(TodoDto newItem)
        {
            var response = await _httpClient.PostAsJsonAsync(url, newItem);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<TodoDto>();
        }

        public async Task<List<TodoDto>?> GetAll()
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<TodoDto>>();
            }
            else
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
        }

        public async Task<TodoDto?> Update(TodoDto item)
        {
            var response = await _httpClient.PutAsJsonAsync(url, item);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<TodoDto>();
        }

        public async Task Delete(string id)
        {
            var response = await _httpClient.DeleteAsync($"{url}?id={id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
        }
    }
}
