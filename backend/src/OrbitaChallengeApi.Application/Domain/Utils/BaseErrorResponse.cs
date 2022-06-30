namespace OrbitaChallengeApi.Application.Domain.Utils;

public class BaseErrorResponse
{
    public List<string> Errors { get; set; } = new List<string>();
}
