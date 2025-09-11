using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Commands;

public class RoomTypeResponse : Response
{
    public int RoomTypeId { get; set; }
    public string RoomTypeName { get; set; } = default!;
}
