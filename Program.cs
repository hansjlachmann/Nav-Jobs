using System;
using System.Threading.Tasks;
using NavJobs;
using ServiceReference;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string navServiceUrl =
                "http://localhost:7649/DynamicsNAVCarloTEST/WS/MOTORFORUM FREDRIKSTAD/Codeunit/TestNavWs";

            var serviceClient = new NavServiceClient();
            var client = serviceClient.CreateClient(navServiceUrl);

            await client.OpenAsync();

            var result = await client.TestHelloWorldAsync("Hello from console");

            Console.WriteLine("NAV returned:");
            Console.WriteLine(result.return_value);

            await client.CloseAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR:");
            Console.WriteLine(ex);
        }
    }
}
