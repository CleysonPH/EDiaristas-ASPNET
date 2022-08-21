using System.Text.Json;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Pagamentos;
using EDiaristas.Core.Extensions;
using EDiaristas.Api.Common.NamingPolicies;

namespace EDiaristas.Core.Services.GatewayPagamento.PagarMe;

public class PagarMeService : IGatewayPagamentoService
{
    private const string Url = "https://api.pagar.me/1/transactions";

    private readonly string _pagarMeApiKey;
    private readonly HttpClient _httpClient;
    private readonly IPagamentoRepository _pagamentoRepository;

    public PagarMeService(
        HttpClient httpClient,
        IConfiguration configuration,
        IPagamentoRepository pagamentoRepository)
    {
        _httpClient = httpClient;
        _pagamentoRepository = pagamentoRepository;
        _pagarMeApiKey = configuration.GetValue<string>("GatewayPagamento:PagarMe:ApiKey");
    }

    public Pagamento Pagar(Diaria diaria, string cardHash)
    {
        var request = criarTransactionRequest(diaria.Preco, cardHash);
        var jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance };
        var response = _httpClient.PostAsJsonAsync(Url, request, jsonSerializerOptions).Result;
        if (response.IsSuccessStatusCode)
        {
            var transactionSuccessResponse = response
                .Content
                .Deserialize<TransactionSuccessResponse>(jsonSerializerOptions);
            return criarPagamento(diaria, transactionSuccessResponse);
        }
        var transactionErrorResponse = response
            .Content
            .Deserialize<TransactionErrorResponse>(jsonSerializerOptions);
        throw new GatewayPagamentoServiceException(transactionErrorResponse.Errors.First().Message);
    }

    public Pagamento Estornar(Diaria diaria)
    {
        if (diaria.Status != DiariaStatus.Pago)
        {
            throw new GatewayPagamentoServiceException("Não é possível estornar uma diária que não foi paga");
        }
        var pagamento = diaria.Pagamentos.FirstOrDefault(p => p.Status == PagamentoStatus.Aceito);
        if (pagamento is null)
        {
            throw new GatewayPagamentoServiceException("Não foi possível encontrar o pagamento para estornar");
        }
        var url = $"{Url}/{pagamento.TransacaoId}/refund";
        var request = new RefundRequest(_pagarMeApiKey);
        var jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance };
        var response = _httpClient.PostAsJsonAsync(url, request, jsonSerializerOptions).Result;
        if (response.IsSuccessStatusCode)
        {
            var refundResponse = response
                .Content
                .Deserialize<RefundResponse>(jsonSerializerOptions);
            return criarPagamento(diaria, refundResponse);
        }
        throw new GatewayPagamentoServiceException("Não foi possível estornar o pagamento");
    }

    private Pagamento criarPagamento(Diaria diaria, RefundResponse refundResponse)
    {
        var pagamento = new Pagamento
        {
            TransacaoId = refundResponse.Id.ToString(),
            DiariaId = diaria.Id,
            Status = PagamentoStatus.Reembolsado,
            Valor = converterCentavosParaReais(refundResponse.Amount)
        };
        return _pagamentoRepository.Create(pagamento);
    }

    private Pagamento criarPagamento(Diaria diaria, TransactionSuccessResponse transactionSuccessResponse)
    {
        var pagamento = new Pagamento
        {
            Valor = diaria.Preco,
            TransacaoId = transactionSuccessResponse.Id.ToString(),
            DiariaId = diaria.Id,
            Status = transactionSuccessResponse.Status == "paid" ? PagamentoStatus.Aceito : PagamentoStatus.Reprovado
        };
        return _pagamentoRepository.Create(pagamento);
    }

    private TransactionRequest criarTransactionRequest(decimal valorEmReais, string cardHash)
    {
        return new TransactionRequest
        {
            ApiKey = _pagarMeApiKey,
            Amount = converterReaisParaCentavos(valorEmReais),
            CardHash = cardHash,
            Async = false
        };
    }

    private int converterReaisParaCentavos(decimal valorEmReais)
    {
        return (int)(valorEmReais * 100);
    }

    private decimal converterCentavosParaReais(int valorEmCentavos)
    {
        return (decimal)valorEmCentavos / 100;
    }
}