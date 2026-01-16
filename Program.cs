using System;
using System.ServiceModel;
using System.Threading.Tasks;
using ServiceReference;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting connection...");

        var binding = new BasicHttpBinding
        {
            SendTimeout = TimeSpan.FromMinutes(1),
            ReceiveTimeout = TimeSpan.FromMinutes(1),
            Security =
            {
                Mode = BasicHttpSecurityMode.TransportCredentialOnly,
                Transport = { ClientCredentialType = HttpClientCredentialType.Windows }
            }
        };

        var endpoint = new EndpointAddress(
            "http://localhost:7649/DynamicsNAVCarloTEST/WS/MOTORFORUM FOLLO/Codeunit/TestNavWs"
        );

        var client = new TestNavWs_PortClient(binding, endpoint);

        client.ClientCredentials.Windows.ClientCredential =
            System.Net.CredentialCache.DefaultNetworkCredentials;
        client.ClientCredentials.Windows.AllowedImpersonationLevel =
            System.Security.Principal.TokenImpersonationLevel.Impersonation;

        try
        {
            var result = await client.HelloWorldAsync("Hello World....!");
            Console.WriteLine("Service responded: " + result.return_value);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connecting to NAV service: " + ex.Message);
        }
    }
}
