using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Queries;

public class GetRoomTypeResponse : Response
{
    public int RoomTypeId { get; set; }
    public string RoomTypeName { get; set; } = default!;
}
