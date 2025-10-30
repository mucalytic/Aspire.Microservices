namespace Aspire.Microservices.Api.Notes;

public static class Constants
{
    public static class EndpointNames
    {
        public static string Notes       => nameof(Notes);
        public static string GetNoteById => nameof(GetNoteById);
    }
    
    public static class HttpClientNames
    {
        public static string TagApi => nameof(TagApi);
    }
}
