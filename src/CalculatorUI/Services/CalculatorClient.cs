using System.Net.Http.Json;

namespace CalculatorUI.Services;

public class CalculatorClient(HttpClient http)
{
    public Task<double?> AddAsync(double a, double b) =>
        GetResultAsync($"api/calculator/add?a={a}&b={b}");

    public Task<double?> SubtractAsync(double a, double b) =>
        GetResultAsync($"api/calculator/subtract?a={a}&b={b}");

    public Task<double?> MultiplyAsync(double a, double b) =>
        GetResultAsync($"api/calculator/multiply?a={a}&b={b}");

    public async Task<(double? Result, string? Error)> DivideAsync(double a, double b)
    {
        var response = await http.GetAsync($"api/calculator/divide?a={a}&b={b}");
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<ResultDto>();
            return (data?.Result, null);
        }
        var err = await response.Content.ReadFromJsonAsync<ErrorDto>();
        return (null, err?.Error ?? "Unknown error");
    }

    private async Task<double?> GetResultAsync(string url)
    {
        var data = await http.GetFromJsonAsync<ResultDto>(url);
        return data?.Result;
    }

    private record ResultDto(double Result);
    private record ErrorDto(string Error);
}
