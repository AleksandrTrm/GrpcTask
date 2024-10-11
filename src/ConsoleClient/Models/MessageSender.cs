using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text.Json;
using Client.Models;
using ConsoleClient.Options;
using Grpc.Net.Client;
using Client;

namespace ConsoleClient.Models;

public class MessageSender
{
    private readonly PacketOptions _options = GetOptions();

    public async Task<List<ResultReply>> SendMessage()
    {
        var client = ConfigureClient();

        var replyList = new List<ResultReply>();
        for (int i = 0; i < _options.TotalPackets; i++)
        {
            var dataList = GetDataList(_options.RecordsInPacket);

            var request = new ConfigurationRequest
            {
                PacketSeqNumber = i,
                PacketTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                NRecords = dataList.Count
            };

            request.PacketData.AddRange(dataList);

            replyList.Add(client.ReadConfiguration(request));
            if (i != _options.TotalPackets)
                await Task.Delay(_options.TimeInterval * 1000);
        }

        return replyList;
    }

    private ReaderConfiguration.ReaderConfigurationClient ConfigureClient()
    {
        var handler = new SocketsHttpHandler
        {
            PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
            KeepAlivePingDelay = TimeSpan.FromSeconds(60),
            KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
            EnableMultipleHttp2Connections = true
        };

        var address = AddressBuilder.NoSecureAddress(_options.GRpcServerAddr, _options.GrpcServerPort);
        
        var channel = GrpcChannel
            .ForAddress(address,
                new GrpcChannelOptions
                {
                    HttpHandler = handler
                });
        
        return new ReaderConfiguration.ReaderConfigurationClient(channel);
    }

    private List<Data> GetDataList(int dataCount)
    {
        var dataList = new List<Data>();
        for (int i = 0; i < dataCount; i++)
        {
            var generator = new DecimalGenerator();

            var data = new Data
            {
                Decimal1 = generator.GenerateDecimal().ToString(CultureInfo.InvariantCulture),
                Decimal2 = generator.GenerateDecimal().ToString(CultureInfo.InvariantCulture),
                Decimal3 = generator.GenerateDecimal().ToString(CultureInfo.InvariantCulture),
                Decimal4 = generator.GenerateDecimal().ToString(CultureInfo.InvariantCulture),
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };

            dataList.Add(data);
        }

        return dataList;
    }

    private static PacketOptions GetOptions()
    {
        //var filePath = "Options/Configuration.json";
        var filePath = "../../../Options/Configuration.json";
        
        var result = JsonSerializer.Deserialize<PacketOptions>(
                File.ReadAllText(filePath),
                JsonSerializerOptions.Default)
            ?? throw new ArgumentException("Missing packet options");

        return result;
    }
}