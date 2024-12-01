namespace AspNetCore.ApiVersioningTest.Constants
{
    public static class ApiVersions
    {
        public const string VERSION_NUMBER = "1.0";
        public const string MINOR_VERSION_NUMBER = "1.1";
        public const int MAJOR = 1;
        public const int MINOR = 1;
        public const string VERSION = $"v{VERSION_NUMBER}";
        public const string MINOR_VERSION = $"v{MINOR_VERSION_NUMBER}";
    }
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
        public const string VERSION_TITLE = $"API - {ApiVersions.VERSION}";

        public const string MINOR_VERSION_TITLE = $"API - {ApiVersions.MINOR_VERSION}";
        public const string GROUP_NAME_FORMAT = "'v'VVV";
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
