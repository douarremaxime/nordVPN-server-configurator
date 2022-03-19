using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text.Json;
using NordVpnServerConfigurator.Classes.Dto;

namespace NordVpnServerConfigurator
{
    class Program
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        static async Task Main(string[] args)
        {
            try
            {
                var hostName = await QueryServerRecommendation();
                UpdateNordVpn(hostName);
                Console.WriteLine($"Done! New server name: {hostName}.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went terribly wrong:");
                Console.WriteLine(e);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static async Task<string> QueryServerRecommendation()
        {
            var responseStream = _client.GetStreamAsync("https://nordvpn.com/wp-admin/admin-ajax.php?action=servers_recommendations&filters={%22servers_technologies%22:[1]}");
            var serverRecommendations = await JsonSerializer.DeserializeAsync<List<ServerRecommendation>>(await responseStream, _options);
            if (serverRecommendations == null) throw new ArgumentNullException("No server recommendation was received from NordVPN.");
            return serverRecommendations.First(s => s.HostName != null).HostName;
        }

        private static void UpdateNordVpn(string hostName)
        {
            var sessionState = InitialSessionState.CreateDefault();
            sessionState.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.Unrestricted;

            sessionState.ImportPSModulesFromPath(@"C:\Windows\system32\WindowsPowerShell\v1.0\Modules\VpnClient\VpnClient.psd1");

            using (PowerShell ps = PowerShell.Create(sessionState))
            {
                ps
                    .AddCommand("Set-VpnConnection")
                    .AddParameter("ConnectionName", "NordVpn")
                    .AddParameter("ServerAddress", hostName)
                    .Invoke();
            }
        }
    }
}