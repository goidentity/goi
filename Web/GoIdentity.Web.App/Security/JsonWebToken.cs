namespace GoIdentity.Web.Security
{
    public class JsonWebToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; } = "bearer";
        public int expires_in { get; set; }
        public string refresh_token { get; set; }

        public int UserId { get; set; }
        public int EmployeeId { get; set; }

        public int OrganizationId { get; set; }
    }
}
