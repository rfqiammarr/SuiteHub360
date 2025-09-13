using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Commands;
public class RoomRequest
{
    public int? RoomId { get; set; }

    [Required]
    [StringLength(50)]
    public string RoomName { get; set; } = default!;

    [Required]
    [StringLength(20)]
    public string RoomNumber { get; set; } = default!;

    [Required]
    public int RoomTypeID { get; set; }

    [Required]
    public int Floor { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = default!;

    [Required]
    [Range(0, double.MaxValue)]
    public decimal PricePerNight { get; set; }

    [StringLength(500)]
    public string Description { get; set; } = default!;

    [Required]
    public DateTime UpdatedAt { get; set; }

    public bool IsBooking { get; set; } = false;
}

