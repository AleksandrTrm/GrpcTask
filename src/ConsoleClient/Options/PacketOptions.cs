namespace ConsoleClient.Options;

public class PacketOptions
{
    public int TotalPackets { get; init; }
    
    public int RecordsInPacket { get; init; }
    
    public int TimeInterval { get; init; }

    public string GRpcServerAddr { get; init; } = string.Empty;

    public int GrpcServerPort { get; init; }
}