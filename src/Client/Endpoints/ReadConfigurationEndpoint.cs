using System.Globalization;
using Client.Models;
using Server;
using Client.Options;
using Client.Requests;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace Client.Endpoints;

public class ReadConfigurationEndpoint(IConfiguration configuration)
{
    private readonly PacketOptions _packetOptions = configuration.GetSection("PacketOptions").Get<PacketOptions>() 
                                                    ?? throw new ArgumentException("Missing packet options");

    public async Task<IEnumerable<ResultReply>> ReadConfigurationAsync(
        [FromBody] PostPacketsRequest request,
        CancellationToken cancellationToken)
    {
        var client = ConfigureClient();
        
        var replyList = new List<ResultReply>();
        foreach (var packet in request.Packets)
        {
            var dataList = GetDataList(packet);

            var configurationRequest = new ConfigurationRequest()
            {
                PacketSeqNumber = packet.PacketSeqNum,
                PacketTimestamp = DateTime.UtcNow.ToTimestamp(),
                NRecords = packet.NRecords
            };

            configurationRequest.PacketData.AddRange(dataList);

            replyList.Add(client.ReadConfiguration(configurationRequest));
            if (packet.PacketSeqNum != request.Packets.Length)
                await Task.Delay(_packetOptions.TimeInterval * 1000, cancellationToken);
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

        var channel = GrpcChannel
            .ForAddress(AddressBuilder.NoSecureAddress(_packetOptions.GRpcServerAddr, _packetOptions.GrpcServerPort), 
                new GrpcChannelOptions
                {
                    HttpHandler = handler
                });
        
        return new ReaderConfiguration.ReaderConfigurationClient(channel);
    }

    private List<Data> GetDataList(Packet packet)
    {
        var dataList = new List<Data>();
        foreach (var packetData in packet.PacketData)
        {
            var data = new Data
            {
                Decimal1 = packetData.Decimal1.ToString(CultureInfo.InvariantCulture),
                Decimal2 = packetData.Decimal2.ToString(CultureInfo.InvariantCulture),
                Decimal3 = packetData.Decimal3.ToString(CultureInfo.InvariantCulture),
                Decimal4 = packetData.Decimal4.ToString(CultureInfo.InvariantCulture),
                Timestamp = DateTime.UtcNow.ToTimestamp()
            };

            dataList.Add(data);
        }

        return dataList;
    }
}