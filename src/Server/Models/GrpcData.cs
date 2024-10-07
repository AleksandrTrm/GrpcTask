using Google.Protobuf.WellKnownTypes;

namespace Server.Models;

public class GrpcData
{
    public GrpcData(
        int packetSeqNum, 
        int recordSeqNum,
        DateTime packetTimestamp, 
        string decimal1, 
        string decimal2, 
        string decimal3, 
        string decimal4, 
        DateTime recordTimestamp)
    {
        PacketSeqNum = packetSeqNum;
        RecordSeqNum = recordSeqNum;
        PacketTimestamp = packetTimestamp;
        Decimal1 = decimal1;
        Decimal2 = decimal2;
        Decimal3 = decimal3;
        Decimal4 = decimal4;
        RecordTimestamp = recordTimestamp;
    }

    public int PacketSeqNum { get; init; }

    public int RecordSeqNum { get; init; }

    public DateTime PacketTimestamp { get; init; }

    public string Decimal1 { get; init; }

    public string Decimal2 { get; init; }

    public string Decimal3 { get; init; }

    public string Decimal4 { get; init; }
    
    public DateTime RecordTimestamp { get; init; }
}