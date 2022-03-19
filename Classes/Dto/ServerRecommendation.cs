namespace NordVpnServerConfigurator.Classes.Dto
{
    public class ServerRecommendation
    {
        public string HostName { get; set; }

        public ServerRecommendation(string hostName)
        {
            HostName = hostName;
        }
    }
}
