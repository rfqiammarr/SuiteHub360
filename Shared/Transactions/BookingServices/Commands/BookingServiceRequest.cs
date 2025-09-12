using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Transactions.BookingServices.Commands;
public class BookingServiceRequest
{
    [Required]
    public Guid BookingServiceID { get; set; }
    [Required]
    public Guid BookingID { get; set; }
    [Required]
    public int ServiceID { get; set; }
    [Required]
    public int Quantity { get; set; }
    public decimal Total { get; set; }
}
