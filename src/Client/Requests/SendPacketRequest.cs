using Google.Protobuf.WellKnownTypes;

namespace Client.Requests;

public record PostPacketsRequest(Packet[] Packets);    

public record Packet(
    DateTime PacketTimestamp,
    int PacketSeqNum,
    int NRecords,
    DTOs.Data[] PacketData);