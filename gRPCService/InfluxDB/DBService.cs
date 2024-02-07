using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core.Exceptions;
using InfluxDB.Client.Writes;

namespace gRPCService.Services;

internal class DBService
{
    static string url = "http://192.168.178.56:8086";
    static string token = "DjyTt1SMSqM_JrvQtPyqBaJXEhAvW7c8e8Lunk0wFvEduPlBeC9LGgJ_9BJQcp9vQEKnJ36tWdfz5NiIU7B-9w==";
    private static readonly string bucket = "livereport";
    private static readonly string org = "ads";
    private static InfluxDBClient client;
    public static string Log = string.Empty;
    public static void Connect()
    {
        if (client != null) return;
        //Console.WriteLine($"URL: {url}\nTOKEN: {token}");
        client = new InfluxDBClient(url, token);
    }
    public static Response WriteData(string payload, ref ILogger<ReportDataService> logger)
    {
        var writeApi = client.GetWriteApi();
        Console.WriteLine("Payload: " + payload);
        Log += $"Payload: {payload}\n";
        writeApi.WriteRecord(payload, WritePrecision.Ns, bucket, org);
        writeApi.Flush();
        return CheckException(writeApi, ref logger);
    }
    public static void Disconnect()
    {
        if (client != null)
        {
            client.Dispose();
            client = null;
        }
    }
    private static Response CheckException(WriteApi writeApi, ref ILogger<ReportDataService> logger)
    {
        List<Response> responses = new List<Response>();
        writeApi.EventHandler += (sender, EventArgs) =>
        {
            Task.Delay(100);
            if (EventArgs is WriteErrorEvent @event)
            {
                try
                {
                    throw @event.Exception;
                }
                catch (BadRequestException ex)
                {
                    responses.Add(new Response { Status = -1 });
                }
            }
        };
        return responses.All(res => res.Status == 0) ?
                            new Response { Status = 0 } :
                            new Response { Status = -1 };
    }
}