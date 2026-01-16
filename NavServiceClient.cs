using System;
using System.ServiceModel;
//using System.Threading.Tasks;
using ServiceReference;
//using System.Xml.Linq;


namespace NavJobs
{

public class NavServiceClient
{
    private static BasicHttpBinding CreateBinding()
    {
        return new BasicHttpBinding
        {
            SendTimeout = TimeSpan.FromMinutes(1),
            ReceiveTimeout = TimeSpan.FromMinutes(1),
            Security =
            {
                Mode = BasicHttpSecurityMode.TransportCredentialOnly,
                Transport =
                {
                    ClientCredentialType = HttpClientCredentialType.Windows
                }
            }
        };
    }

    public TestNavWs_PortClient CreateClient(string navServiceUrl)
    {
        var client = new TestNavWs_PortClient(
            CreateBinding(),
            new EndpointAddress(navServiceUrl)
        );

        client.ClientCredentials.Windows.ClientCredential =
            System.Net.CredentialCache.DefaultNetworkCredentials;

        return client;
    }
}

}
