using Asp.Versioning.ApiExplorer;
using Asp.Versioning;

namespace Aspire.Microservices.Api.Notes.Options;

public static class ApiOptions
{
    public static Action<ApiExplorerOptions> ApiExplorerOptions { get; } =
        options =>
        {
            options.GroupNameFormat           = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        };

    public static Action<ApiVersioningOptions> ApiVersioningOptions { get; } =
        options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ApiVersionReader  = new UrlSegmentApiVersionReader();
        };
}
