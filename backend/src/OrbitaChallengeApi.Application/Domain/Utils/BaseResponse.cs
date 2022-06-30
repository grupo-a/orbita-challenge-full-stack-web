using System.Text.Json.Serialization;

namespace OrbitaChallengeApi.Application.Domain.Utils;


public class BaseResponse<T>
{
    public BaseResponse()
    {
    }

    public BaseResponse(T? data)
    {
        Data = data;
    }

    public BaseResponse(T? data, int? count, int? totalCount)
    {
        Data = data;
        Count = count;
        TotalCount = totalCount;
    }
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    [JsonPropertyName("count")]
    public int? Count { get; set; } = 0;
    [JsonPropertyName("totalCount")]
    public int? TotalCount { get; set; } = 0;
}