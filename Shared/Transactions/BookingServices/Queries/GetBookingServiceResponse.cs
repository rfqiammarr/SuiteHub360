using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Transactions.BookingServices.Queries;

public class GetBookingServiceResponse : Response
{
    public Guid BookingServiceID { get; set; }
    public string BookingServiceName { get; set; } = string.Empty;
    public Guid BookingID { get; set; }
    public string BookingName { get; set; } = string.Empty;
    public int ServiceID { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Total { get; set; }
}
