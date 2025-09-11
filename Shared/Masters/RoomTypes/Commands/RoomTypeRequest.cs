using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Commands;
public class RoomTypeRequest
{
    [Required]
    [StringLength(15)]
    public string RoomTypeName { get; set; } = default!;
}
