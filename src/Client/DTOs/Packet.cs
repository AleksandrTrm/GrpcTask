namespace Client.DTOs;

public class Packet
{
    public DateTime PacketTimestamp { get; init; }
    
    public int PacketSeqNumber { get; init; }

    public int NumberOfRecords { get; init; }

    public int NRecords { get; init; }

    public IEnumerable<Data> PacketData { get; init; } = [];
}