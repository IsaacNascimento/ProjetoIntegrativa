using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FrontEnd.Models;
using Newtonsoft.Json;

public static class ApiClient
{
    private static readonly HttpClient _http;

    static ApiClient()
    {
        var baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        if (string.IsNullOrEmpty(baseUrl))
            throw new InvalidOperationException("ApiBaseUrl não configurada no Web.config");

        _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
        _http.DefaultRequestHeaders.Accept.Clear();
        _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    // GENERIC HELPERS
    private static async Task<T> ReadResponse<T>(HttpResponseMessage res)
    {
        res.EnsureSuccessStatusCode();
        var json = await res.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(json);
    }

    public static async Task<List<CotacaoDTO>> GetCotacoesAsync()
    {
        var res = await _http.GetAsync("api/Cotacao");
        return await ReadResponse<List<CotacaoDTO>>(res);
    }

    public static async Task<CotacaoDTO> GetCotacaoPorIdAsync(int id)
    {
        var res = await _http.GetAsync($"api/Cotacao/{id}");
        return await ReadResponse<CotacaoDTO>(res);
    }

    public static async Task<CotacaoDTO> ObterCotacaoDeMenorValorAsync()
    {
        var res = await _http.GetAsync("api/Cotacao/ObterCotacaoDeMenorValor");
        return await ReadResponse<CotacaoDTO>(res);
    }

    public static async Task CreateCotacaoAsync(CotacaoCreate dto)
    {
        var json = JsonConvert.SerializeObject(dto);
        System.Diagnostics.Debug.WriteLine("Enviando JSON para API:");
        System.Diagnostics.Debug.WriteLine(json);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var res = await _http.PostAsync("api/Cotacao", content);
        var body = await res.Content.ReadAsStringAsync();

        if (!res.IsSuccessStatusCode)
            throw new InvalidOperationException($"HTTP {(int)res.StatusCode} {res.ReasonPhrase}: {body}");
        res.EnsureSuccessStatusCode();
    }

    public static async Task<List<ProdutoDTO>> GetProdutosAsync()
    {
        var res = await _http.GetAsync("api/Produto");
        return await ReadResponse<List<ProdutoDTO>>(res);
    }

    public static async Task CreateProdutoAsync(ProdutoDTO dto)
    {
        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var res = await _http.PostAsync("api/Produto", content);
        var body = await res.Content.ReadAsStringAsync();

        if (!res.IsSuccessStatusCode)
            throw new InvalidOperationException($"HTTP {(int)res.StatusCode} {res.ReasonPhrase}: {body}");

        res.EnsureSuccessStatusCode();
    }

    public static async Task<List<FornecedorDTO>> GetFornecedoresAsync()
    {
        var res = await _http.GetAsync("api/Fornecedor");
        return await ReadResponse<List<FornecedorDTO>>(res);
    }

    public static async Task CreateFornecedorAsync(FornecedorDTO dto)
    {
        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var res = await _http.PostAsync("api/Fornecedor", content);
        var body = await res.Content.ReadAsStringAsync();

        if (!res.IsSuccessStatusCode)
            throw new InvalidOperationException($"HTTP {(int)res.StatusCode} {res.ReasonPhrase}: {body}");

        res.EnsureSuccessStatusCode();
    }
}
