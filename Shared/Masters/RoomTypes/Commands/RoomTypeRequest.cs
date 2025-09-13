using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Commands;
public class RoomTypeRequest
{
    public int? RoomTypeId { get; set; }
    [Required]
    [StringLength(25)]
    public string RoomTypeName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Capacity { get; set; }
    public decimal BasePrice { get; set; }
}
