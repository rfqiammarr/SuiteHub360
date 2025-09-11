using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Commands;

public class RoomResponse : Response
{
    public int RoomId { get; set; }
    public string RoomName { get; set; } = default!;
}
