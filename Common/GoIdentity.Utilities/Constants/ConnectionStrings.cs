namespace GoIdentity.Utilities.Constants
{
    public sealed class ConnectionStrings
    {
        public static string COMMON_CONNECTION_STRING { get; set; }
        public static string SERVER_NAME { get; set; }
        public static string SERVER_CREDENTIALS { get; set; }
        public static int COMMAND_TIMEOUT { get; set; }
        public static bool IsCompanyDbSqlAuthentication { get; set; }

        public static string REPORTS_OUTPUT_PATH { get; set; }
        public static string DOCS_PATH { get; set; }
        public static string QtBinaries_PATH { get; set; }

        public static string GOOGLE_AUTH_SECRET_KEY { get; set; }
    }
}
