using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Queries;

public class GetRoomTypeResponse : Response
{
    public int RoomTypeID { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Capacity { get; set; }
    public decimal BasePrice { get; set; }
}
