using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Queries;

public class GetRoomResponse : Response
{
    public int RoomId { get; set; }
    public string RoomName { get; set; } = default!;
}
