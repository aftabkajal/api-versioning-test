namespace AspNetCore.ApiVersioningTest.Constants
{
    /// <summary>
    /// Configuration for CORS policies.
    /// </summary>
    public static class CORSConfigurations
    {
        public const string KEY = "CORS";

        public const string POLICY_NAME = "CustomCorsPolicy";
    }

    /// <summary>
    /// Configuration for API versioning.
    /// Dynamically retrieves version details from environment variables or defaults to predefined values.
    /// </summary>
    public static class ApiVersionConfiguration
    {        
        // Derived versioning information
        public const string Major = "1";
        public const string Minor = "1";
        public const string GroupNameFormat = "'v'VVV";

        public static readonly string Version = $"v{Major}.0";
        public static readonly string MinorVersion = $"v{Major}.{Minor}";

        public static readonly string VersionTitle = $"API - {Version}";
        public static readonly string MinorVersionTitle = $"API - {MinorVersion}";
    }

    /// <summary>
    /// Commonly used content types for API responses.
    /// </summary>
    public static class ContentTypes
    {
        public const string APPLICATION_JSON = "application/json";
        public const string APPLICATION_XML = "application/xml"; // Add if XML is supported.
        public const string TEXT_PLAIN = "text/plain";           // Add if plain text is supported.
    }
}
