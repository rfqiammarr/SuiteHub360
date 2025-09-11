using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Commands;
public class RoomRequest
{
    [Required]
    [StringLength(20)]
    public string RoomName { get; set; } = default!;
}
