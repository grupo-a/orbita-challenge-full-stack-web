using Microsoft.AspNetCore.Mvc;

namespace OrbitaChallengeApi.Application.Domain.Filters.Base;

public abstract class FilterBase
{
    [FromQuery(Name = "search")]
    public string? Search { get; set; }

    [FromQuery(Name = "take")]
    public int? Take { get; set; }

    [FromQuery(Name = "skip")]
    public int? Skip { get; set; }

    [FromQuery(Name = "order")]
    public string Order { get; set; } = "default";

    [FromQuery(Name = "desc")]
    public bool Desc { get; set; } = false;
}
