namespace GoIdentity.Entities.Security
{
    public class UserLoginLog
    {
        public int UserId { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string AppKey { get; set; }

        public short OrganizationId { get; set; }

        public string DeviceId { get; set; }
        public string LocalIPAddress { get; set; }
        public string RemoteIPAddress { get; set; }
    }
}